// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NuGet.Packaging.Core;
using NuGet.Versioning;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Microsoft.NET.Build.Tasks
{
    /// <summary>
    /// Parses the output artifact.xml generated by ComposeStore
    /// </summary>
    internal class StoreArtifactParser
    {
        internal static HashSet<PackageIdentity> Parse(string filterFile)
        {
            var listofPackages = new HashSet<PackageIdentity>();
            var doc = XDocument.Load(filterFile);
            var rootName = doc.Root.Name;

            if (!rootName.LocalName.Equals("StoreArtifacts"))
            {
                throw new BuildErrorException(Strings.IncorrectTargetFormat, filterFile);
            }

            var ns = rootName.Namespace;

            foreach (var pkginfo in doc.Root.Elements(ns + "Package"))
            {
                var pkgname = pkginfo.Attribute("Id");
                var version = pkginfo.Attribute("Version");

                if (pkgname != null && version != null)
                {
                    listofPackages.Add(new PackageIdentity(pkgname.Value, NuGetVersion.Parse(version.Value)));
                }
            }

            return listofPackages;
        }
    }

}


