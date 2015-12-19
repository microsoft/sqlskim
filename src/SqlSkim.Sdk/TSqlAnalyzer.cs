//// Copyright (c) Microsoft. All rights reserved.
//// Licensed under the MIT license. See LICENSE file in the project root for full license information.

//using System;
//using System.Collections.Generic;

//using Microsoft.SqlServer.TransactSql.ScriptDom;

//namespace Microsoft.CodeAnalysis.Sql.Sdk
//{
//    public class TSqlAnalyzer
//    {
//        Dictionary<Type, List<ISqlSkimmer>> typeToSkimmersMap;

//        public TSqlAnalyzer(IEnumerable<ISqlSkimmer> skimmers)
//        {
//            this.typeToSkimmersMap = new Dictionary<Type, List<ISqlSkimmer>>();

//            foreach (ISqlSkimmer skimmer in skimmers)
//            {
//                foreach (Type type in skimmer.Types)
//                {
//                    List<ISqlSkimmer> skimmersList;

//                    if (!this.typeToSkimmersMap.TryGetValue(type, out skimmersList))
//                    {
//                        skimmersList = this.typeToSkimmersMap[type] = new List<ISqlSkimmer>();
//                    }
//                    skimmersList.Add(skimmer);
//                }
//            }
//        }

//        public void AnalyzeFragment(SqlFileContext context, TSqlFragment fragment)
//        {
//            var visitor = new AllNodesVisitor(
//                (node) =>
//                {
//                    List<ISqlSkimmer> skimmersList;

//                    if (this.typeToSkimmersMap.TryGetValue(node.GetType(), out skimmersList))
//                    {
//                        foreach (ISqlSkimmer skimmer in skimmersList)
//                        {
//                            context.Fragment = node;
//                            skimmer.Analyze(context);
//                        }
//                    }
//                }
//                );
//            fragment.Accept(visitor);
//        }
//    }
//}
