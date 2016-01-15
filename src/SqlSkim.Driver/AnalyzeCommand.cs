// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Reflection;

using Microsoft.CodeAnalysis.Sarif.Driver.Sdk;
using Microsoft.CodeAnalysis.Sql.Rules;
using Microsoft.CodeAnalysis.Sql.Sdk;
using Microsoft.SqlServer.TransactSql.ScriptDom;

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

        protected override void AnalyzeTarget(IEnumerable<ISkimmer<SqlFileContext>> skimmers, SqlFileContext context, HashSet<string> disabledSkimmers)
        {
            TSqlFragment tsqlFragment;

            IList<ParseError> parseErrors = context.TryGetTSqlFragment(out tsqlFragment);

            if (parseErrors.Count > 0)
            {
                foreach (ParseError parseError in parseErrors)
                {
                    Errors.LogTargetParseError(context, parseError.CreateRegion(), parseError.Message);
                }
                return;
            }

            context.Fragment = tsqlFragment;

            TSqlAnalyzer analyzer = new TSqlAnalyzer(skimmers, disabledSkimmers);
            analyzer.Analyze(context);

            RuntimeErrors |= analyzer.RuntimeErrors;
        }
    }
}
