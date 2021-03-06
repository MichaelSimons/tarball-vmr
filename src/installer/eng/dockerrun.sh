#!/usr/bin/env bash
#
# Copyright (c) .NET Foundation and contributors. All rights reserved.
# Licensed under the MIT license. See LICENSE file in the project root for full license information.
#

set -e

SOURCE="${BASH_SOURCE[0]}"
while [ -h "$SOURCE" ]; do # resolve $SOURCE until the file is no longer a symlink
  DIR="$( cd -P "$( dirname "$SOURCE" )" && pwd )"
  SOURCE="$(readlink "$SOURCE")"
  [[ "$SOURCE" != /* ]] && SOURCE="$DIR/$SOURCE" # if $SOURCE was a relative symlink, we need to resolve it relative to the path where the symlink file was located
done
DIR="$( cd -P "$( dirname "$SOURCE" )" && pwd )"

cd "$DIR/.."

INTERACTIVE="-i"

while [[ $# > 0 ]]; do
    key=$1

    case $key in
        --non-interactive)
            INTERACTIVE=
            ;;
        -i|--image)
            DOCKER_IMAGENAME=$2
            shift
            ;;
        -d|--dockerfile)
            DOCKERFILE=$2
            shift
            ;;
        -h|-?|--help)
            echo "Usage: $0 [-d|--dockerfile <Dockerfile>] [-i|--image <ImageName>] <Command>"
            echo ""
            echo "Options:"
            echo "  <Dockerfile>    The path to the Dockerfile to use to create the build container"
            echo "  <ImageName>     The name of an existing Dockerfile folder under eng/docker to use as the Dockerfile"
            echo "  <Command>  The command to run once inside the container (repo root is mapped to DOCKER_HOST_SHARE_DIR; defaults to nothing, which runs the default shell)"
            exit 0
            ;;
        *)
            break # the first non-switch we get ends parsing
            ;;
    esac

    shift
done

if [ -z "$DOCKERFILE" ]; then
    if [ -z "$DOCKER_IMAGENAME" ]; then
        if [ "$(uname)" == "Darwin" ]; then
            echo "Defaulting to 'ubuntu' image for Darwin"
            export DOCKERFILE=eng/docker/ubuntu
        elif [ "$(cat /etc/*-release | grep -cim1 ubuntu)" -eq 1 ]; then
            echo "Detected current OS as Ubuntu, determining ubuntu version to use..."
            if [ "$(cat /etc/*-release | grep -cim1 16.04)" -eq 1 ]; then
                echo "using 'ubuntu.16.04' image"
                export DOCKERFILE=eng/docker/ubuntu.16.04
            else
                echo "using 'ubuntu' image"
                export DOCKERFILE=eng/docker/ubuntu
            fi
        elif [ "$(cat /etc/*-release | grep -cim1 centos)" -eq 1 ]; then
            echo "Detected current OS as CentOS, using 'centos' image"
            export DOCKERFILE=eng/docker/centos
        elif [ "$(cat /etc/*-release | grep -cim1 rhel)" -eq 1 ]; then
            echo "Detected current OS as rhel, using 'rhel' image"
            export DOCKERFILE=eng/docker/rhel
        elif [ "$(cat /etc/*-release | grep -cim1 debian)" -eq 1 ]; then
            echo "Detected current OS as Debian, using 'debian' image"
            export DOCKERFILE=eng/docker/debian
        elif [ "$(cat /etc/*-release | grep -cim1 fedora)" -eq 1 ]; then
            echo "Detected current OS as Fedora, determining fedora version to use..."
            if [ "$(cat /etc/*-release | grep -cim1 23)" -eq 1 ]; then
                echo "using 'fedora.23' image"
                export DOCKERFILE=eng/docker/fedora.23
            fi
        else
            echo "Unknown Linux Distro. Using 'ubuntu' image"
            export DOCKERFILE=eng/docker/ubuntu
        fi
    else
        echo "Using requested image: $DOCKER_IMAGENAME"
        export DOCKERFILE="eng/docker/$DOCKER_IMAGENAME"
    fi
fi

[ -z "$DOTNET_BUILD_CONTAINER_TAG" ] && DOTNET_BUILD_CONTAINER_TAG="dotnetcli-build"
[ -z "$DOTNET_BUILD_CONTAINER_NAME" ] && DOTNET_BUILD_CONTAINER_NAME="dotnetcli-build-container"
[ -z "$DOCKER_HOST_SHARE_DIR" ] && DOCKER_HOST_SHARE_DIR=$(pwd)

# Make container names CI-specific if we're running in CI
#  Jenkins
[ ! -z "$BUILD_TAG" ] && DOTNET_BUILD_CONTAINER_NAME="$BUILD_TAG"
#  VSO
[ ! -z "$BUILD_BUILDID" ] && DOTNET_BUILD_CONTAINER_NAME="$BUILD_BUILDID"

function retry {
  local max_count=$1
  shift

  local count=0
  until "$@"; do
    exit=$?
    wait=$((2 ** $count))
    count=$(($count + 1))
    if [[ ${count} -lt ${max_count} ]]; then
      echo "Retry $count/$max_count returned $exit, wait $wait seconds..."
      sleep ${wait}
    else
      echo "Retry $count/$max_count returned $exit."
      return ${exit}
    fi
  done
  return 0
}

# Build the docker container (will be fast if it is already built)
# with retry since docker pull has high failure rate
echo "Building Docker Container using Dockerfile: $DOCKERFILE"
retry 10 docker build --build-arg WORK_DIR=$DOCKER_HOST_SHARE_DIR --build-arg USER_ID=$(id -u) -t $DOTNET_BUILD_CONTAINER_TAG $DOCKERFILE 2>&1

# Run the build in the container
echo "Launching build in Docker Container"
echo "Running command: $BUILD_COMMAND"
echo "Using code from: $DOCKER_HOST_SHARE_DIR"
[ -z "$INTERACTIVE" ] || echo "Running Interactive"

# Note: passwords/keys should not be passed in the environment
docker run $INTERACTIVE -t --rm --sig-proxy=true \
    --name $DOTNET_BUILD_CONTAINER_NAME \
    -v $DOCKER_HOST_SHARE_DIR:$DOCKER_HOST_SHARE_DIR \
    -e CHANNEL \
    -e DOTNET_BUILD_SKIP_CROSSGEN \
    -e PUBLISH_TO_AZURE_BLOB \
    -e NUGET_FEED_URL \
    -e NUGET_API_KEY \
    -e ARTIFACT_STORAGE_ACCOUNT \
    -e ARTIFACT_STORAGE_CONTAINER \
    -e CHECKSUM_STORAGE_ACCOUNT \
    -e CHECKSUM_STORAGE_CONTAINER \
    -e BLOBFEED_STORAGE_CONTAINER \
    -e CLIBUILD_SKIP_TESTS \
    -e COMMITCOUNT \
    -e DROPSUFFIX \
    -e RELEASESUFFIX \
    -e COREFXAZURECONTAINER \
    -e AZUREACCOUNTNAME \
    -e RELEASETOOLSGITURL \
    -e CORESETUPBLOBROOTURL \
    -e PB_ASSETROOTURL \
    -e PB_PACKAGEVERSIONPROPSURL \
    -e PB_PUBLISHBLOBFEEDURL \
    -e _PUBLISHBLOBFEEDURL \
    -e _ASSETROOTURL \
    -e _PACKAGEVERSIONPROPSURL \
    -e EXTERNALRESTORESOURCES \
    -e BUILD_REPOSITORY_URI \
    -e BUILD_REPOSITORY_NAME \
    -e BUILD_SOURCEBRANCH \
    -e BUILD_BUILDNUMBER \
    -e BUILD_BUILDID \
    -e BUILD_SOURCEVERSION \
    -e SYSTEM_TEAMPROJECT \
    -e POSTBUILDSIGN \
    -e SYSTEM_DEFINITIONID \
    -e SYSTEM_TEAMFOUNDATIONCOLLECTIONURI \
    -e AGENT_JOBNAME \
    -e AGENT_OS \
    -e VSS_NUGET_URI_PREFIXES \
    -e VSS_NUGET_ACCESSTOKEN \
    -e DOTNET_SYSTEM_NET_HTTP_USESOCKETSHTTPHANDLER=0 \
    -e NUGET_CREDENTIALPROVIDER_SESSIONTOKENCACHE_ENABLED=true \
    $DOTNET_BUILD_CONTAINER_TAG \
    $BUILD_COMMAND "$@"
