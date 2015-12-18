// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Composition;
using Microsoft.CodeAnalysis.Sarif.Sdk;
using Microsoft.CodeAnalysis.Sql.Sdk;

namespace Microsoft.CodeAnalysis.Sql.Rules
{
    [Export(typeof(ISqlSkimmer)), Export(typeof(IRuleDescriptor))]
    public class RemoveUnusedVariables : SqlSkimmerBase
    {
        public override string Id { get { return RuleIds.RemoveUnusedVariables; } }

        public override string FullDescription { get { return RuleResources.SQL2001_RemoveUnusedVariables_Description; } }

        public override void Analyze(SqlFileContext context)
        {
            return;
        }
    }
}
