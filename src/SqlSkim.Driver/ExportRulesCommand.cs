// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Reflection;

using Microsoft.CodeAnalysis.Sarif.Driver.Sdk;
using Microsoft.CodeAnalysis.Sql.Rules;

namespace Microsoft.CodeAnalysis.Sql
{
    internal class ExportRulesMetadataCommand : ExportRulesMetadataCommandBase
    {
        public override IEnumerable<Assembly> DefaultPlugInAssemblies
        {
            get
            {
                return new Assembly[] {
                    typeof(RemoveUnusedVariables).Assembly
                };
            }
        }

        public override string Prerelease { get { return VersionConstants.Prerelease; } }
    }
}
