// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using CommandLine;

namespace Microsoft.CodeAnalysis.Sql
{
    [Verb("visit", HelpText = "Visit a TSQL file and dump its structure to console.")]
    public class VisitOptions
    {
        [Value(0,
               HelpText = "A path to a TSQL file.")]
        public string FilePath { get; internal set; }
    }
}

