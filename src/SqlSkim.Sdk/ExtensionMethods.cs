// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.CodeAnalysis.Sarif.Sdk;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Microsoft.CodeAnalysis.Sql
{
    public static class ExtensionMethod
    {
        public static Region CreateRegion(this ParseError parseError)
        {
            var region = new Region();
            region.StartLine = parseError.Line;
            region.StartColumn = parseError.Column;
            return region;
        }

        public static Region CreateRegion(this TSqlFragment tsqlFragment)
        {
            var region = new Region();
            region.StartLine = tsqlFragment.StartLine;
            region.StartColumn = tsqlFragment.StartColumn;
                        
            // TODO disabled pending SourceMap port
            //region.CharOffset = tsqlFragment.StartOffset;
            //region.Length = tsqlFragment.FragmentLength;

            // TODO this is only true for regions that don't span multiple lines
            region.EndColumn = region.StartColumn + tsqlFragment.FragmentLength;

            return region;
        }
    }
}
