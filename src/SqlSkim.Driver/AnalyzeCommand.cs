// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Reflection;

using Microsoft.CodeAnalysis.Sarif.Driver.Sdk;
using Microsoft.CodeAnalysis.Sql.Rules;

namespace Microsoft.CodeAnalysis.Sql
{
    public class AnalyzeCommand : AnalyzeCommandBase<SqlFileContext, AnalyzeOptions>
    {
        // No tool-specific function as yet, so only verbose 'analyzing file'
        // output indicates tool is functioning. 
        //
        // e.g.: sqlsqim analyze c:\test\*.sql --verbose

        public override IEnumerable<Assembly> DefaultPlugInAssemblies
        {
            get
            {
                return new Assembly[] {
                    typeof(AvoidVariableLengthTypesOfSmallSize).Assembly
                };
            }
        }

        public override string Prerelease { get { return VersionConstants.Prerelease; } }
    }
}
