// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.IO;
using Microsoft.NET.TestFramework;
using Microsoft.NET.TestFramework.Assertions;
using Microsoft.NET.TestFramework.Commands;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.NET.Pack.Tests
{
    public class GivenThatWeWantToPackACrossTargetedLibrary : SdkTest
    {
        public GivenThatWeWantToPackACrossTargetedLibrary(ITestOutputHelper log) : base(log)
        {
        }

        [RequiresMSBuildVersionFact("17.1.0.60101")]
        public void It_packs_nondesktop_library_successfully_on_all_platforms()
        {
            var testAsset = _testAssetsManager
                .CopyTestAsset("CrossTargeting")
                .WithSource();

            var libraryProjectDirectory = Path.Combine(testAsset.TestRoot, "NetStandardAndNetCoreApp");

            new PackCommand(Log, libraryProjectDirectory)
                .Execute()
                .Should()
                .Pass();

            var outputDirectory = new DirectoryInfo(Path.Combine(libraryProjectDirectory, "bin", "Debug"));
            outputDirectory.Should().OnlyHaveFiles(new[] {
                "NetStandardAndNetCoreApp.1.0.0.nupkg",
                $"{ToolsetInfo.CurrentTargetFramework}/NetStandardAndNetCoreApp.dll",
                $"{ToolsetInfo.CurrentTargetFramework}/NetStandardAndNetCoreApp.pdb",
                $"{ToolsetInfo.CurrentTargetFramework}/NetStandardAndNetCoreApp.runtimeconfig.json",
                $"{ToolsetInfo.CurrentTargetFramework}/NetStandardAndNetCoreApp.deps.json",
                $"{ToolsetInfo.CurrentTargetFramework}/Newtonsoft.Json.dll",
                $"{ToolsetInfo.CurrentTargetFramework}/NetStandardAndNetCoreApp{EnvironmentInfo.ExecutableExtension}",
                "netstandard1.5/NetStandardAndNetCoreApp.dll",
                "netstandard1.5/NetStandardAndNetCoreApp.pdb",
                "netstandard1.5/NetStandardAndNetCoreApp.deps.json"
            });
        }
    }
}
