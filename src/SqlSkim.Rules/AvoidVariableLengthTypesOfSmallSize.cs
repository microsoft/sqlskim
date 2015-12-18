// Copyright(c) Microsoft.All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;

using Microsoft.CodeAnalysis.Driver.Sdk;
using Microsoft.CodeAnalysis.Sarif.Sdk;
using Microsoft.CodeAnalysis.Sql.Sdk;

namespace Microsoft.CodeAnalysis.Sql.Rules
{
    /// <summary>
    /// SQL2009: When you use data types of variable length such as VARCHAR, NVARCHAR, and
    /// VARBINARY, you incur an additional storage cost to track the length of the value
    /// stored in the data type. In addition, columns of variable length are stored after all
    /// columns of fixed length, which can have performance implications. This rule also fires
    /// in cases where a type of variable length, such as VARCHAR, is declared with no explicit
    /// length. In this case, if specified, the default length is 1. Note that data for types
    /// of variable length is physically stored after data for types of fixed length. Therefore,
    /// you will cause data movement if you change a column from variable to fixed length in
    /// a table that is not empty.
    /// </summary>
    [Export(typeof(ISqlSkimmer)), Export(typeof(IRuleDescriptor)), Export(typeof(IOptionsProvider))]
    public class AvoidVariableLengthTypesOfSmallSize : SqlSkimmerBase, IOptionsProvider
    {
        public override string Id { get { return RuleIds.RemoveUnusedVariables; } }

        public override string FullDescription { get { return RuleResources.SQL2009_AvoidVariableLengthTypesOfSmallSize_Description; } }

        public IEnumerable<IOption> GetOptions()
        {
            return new List<IOption>
            {
                SmallSizeThreshold,
            }.ToImmutableArray();
        }

        private const string AnalyzerName = RuleIds.AvoidVariableLengthTypesOfSmallSize + "." + nameof(AvoidVariableLengthTypesOfSmallSize);

        /// <summary>
        // An inclusive integer value that specifies the upper-bound of what is regarded as a type
        // of small size. A value of 2, for example, configures analysis to regard any type of size
        // 1 or 2 to be regarded as small.
        /// </summary>
        public static PerLanguageOption<int> SmallSizeThreshold { get; } =
            new PerLanguageOption<int>(
                AnalyzerName, 
                nameof(SmallSizeThreshold), 
                defaultValue: () => { return 2; },
                description: RuleResources.SQL2009_AvoidVariableLengthTypesOfSmallSize_SmallSizeThreshold_Description);

        public override void Analyze(SqlFileContext context)
        {
            return;
        }
    }
}
