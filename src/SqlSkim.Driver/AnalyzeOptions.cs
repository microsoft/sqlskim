// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.


using CommandLine;

using Microsoft.CodeAnalysis.Sarif.Driver.Sdk;

namespace Microsoft.CodeAnalysis.Sql
{
    [Verb("analyze", HelpText = "Analyze one or more SQl files for security and correctness issues.")]
    public class AnalyzeOptions : AnalyzeOptionsBase
    {
        // We currently implement no options over the base configuration
    }
}