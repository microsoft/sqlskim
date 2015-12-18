// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.CodeAnalysis.Driver.Sdk;

using CommandLine;

namespace Microsoft.CodeAnalysis.Sql
{
    internal class SqlSkim
    {
        internal static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<
                ExportConfigurationOptions,
                ExportRulesMetadataOptions>(args)
                .MapResult(
                (ExportConfigurationOptions exportConfigurationOptions) => new ExportConfigurationCommand().Run(exportConfigurationOptions),
                (ExportRulesMetadataOptions exportRulesMetadataOptions) => new ExportRulesMetadataCommand().Run(exportRulesMetadataOptions),
                errs => 1);
        }
    }
}
