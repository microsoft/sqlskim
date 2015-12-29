// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Sarif.Driver.Sdk;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Microsoft.CodeAnalysis.Sql.Sdk
{
    public class TSqlAnalyzer
    {
        private SqlFileContext context;
        private HashSet<string> disabledSkimmers;
        private Dictionary<Type, List<ISkimmer<SqlFileContext>>> typeToSkimmersMap;

        public RuntimeConditions RuntimeErrors { get; set; }

        public TSqlAnalyzer(IEnumerable<ISkimmer<SqlFileContext>> skimmers, HashSet<string> disabledSkimmers)
        {
            this.disabledSkimmers = disabledSkimmers;
            this.typeToSkimmersMap = new Dictionary<Type, List<ISkimmer<SqlFileContext>>>();

            foreach (ISqlSkimmer skimmer in skimmers)
            {
                if (disabledSkimmers.Contains(skimmer.Id)) { continue; }

                foreach (Type type in skimmer.Types)
                {
                    List<ISkimmer<SqlFileContext>> skimmersList;

                    if (!this.typeToSkimmersMap.TryGetValue(type, out skimmersList))
                    {
                        skimmersList = this.typeToSkimmersMap[type] = new List<ISkimmer<SqlFileContext>>();
                    }
                    skimmersList.Add(skimmer);
                }
            }
        }

        public void Analyze(SqlFileContext context)
        {
            this.context = context;
            var visitor = new AllNodesVisitor(NodeAction);
            this.context.Fragment.Accept(visitor);
        }

        private void NodeAction(TSqlFragment node)
        {
            List<ISkimmer<SqlFileContext>> skimmersList;

            if (node == null) { return; }

            if (this.typeToSkimmersMap.TryGetValue(node.GetType(), out skimmersList))
            {
                foreach (ISqlSkimmer skimmer in skimmersList)
                {
                    this.context.Fragment = node;
                    try
                    {
                        skimmer.Analyze(this.context);
                    }
                    catch (Exception ex)
                    {
                        RuntimeErrors |= AnalyzeCommand.LogUnhandledRuleExceptionAnalyzingTarget(
                            this.disabledSkimmers,
                            this.context,
                            skimmer,
                            ex);
                    }
                }
            }
        }
    }
}
