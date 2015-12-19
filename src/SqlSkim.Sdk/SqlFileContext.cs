// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;

using Microsoft.CodeAnalysis.Sarif.Driver.Sdk;
using Microsoft.CodeAnalysis.Sarif.Sdk;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Microsoft.CodeAnalysis.Sql
{
    public class SqlFileContext : IAnalysisContext
    {
        private static HashSet<string> ValidFileExtensions = new HashSet<string>(
            new string[] { ".sql" }, StringComparer.OrdinalIgnoreCase);

        private object lockObject;
        private TSqlFragment tsqlFragment;

        public SqlFileContext()
        {
            this.lockObject = new object();
        }

        public bool IsValidAnalysisTarget
        {
            get
            {
                return ValidFileExtensions.Contains(Path.GetExtension(this.TargetUri.LocalPath));
            }
        }

        public TSqlFragment GetTSqlFragment()
        {
            if (this.tsqlFragment != null)
            {
                return this.tsqlFragment;
            }

            lock (this.lockObject)
            {
                if (this.tsqlFragment == null)
                {
                    var parser = new TSql120Parser(initialQuotedIdentifiers: false);

                    IList<ParseError> errors;
                    using (StringReader reader = new StringReader(File.ReadAllText(TargetUri.LocalPath)))
                    {
                        this.tsqlFragment = parser.Parse(reader, out errors);
                    }

                    if (errors.Count > 0)
                    {
                        // TODO 
                        throw new InvalidOperationException();
                    }
                }
            }
            return this.tsqlFragment;
        }

        public IResultLogger Logger { get; set; }

        public PropertyBag Policy { get; set; }

        public IRuleDescriptor Rule { get; set; }

        public Exception TargetLoadException { get; set; }

        public Uri TargetUri { get; set; }

        public void Dispose()
        {
        }
    }
}
