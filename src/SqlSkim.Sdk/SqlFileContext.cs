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

        public IList<ParseError> TryGetTSqlFragment(out TSqlFragment fragment)
        {
            IList<ParseError> errors;

            if (this.tsqlFragment != null)
            {
                fragment = this.tsqlFragment;
                return null;
            }

            errors = null;
            fragment = null;

            lock (this.lockObject)
            {
                if (this.tsqlFragment == null)
                {
                    var parser = new TSql120Parser(initialQuotedIdentifiers: false);

                    using (StringReader reader = new StringReader(File.ReadAllText(TargetUri.LocalPath)))
                    {
                        this.tsqlFragment = parser.Parse(reader, out errors);
                    }
                }
            }

            fragment = this.tsqlFragment;
            return errors;
        }

        public TSqlFragment Fragment { get; set; }

        public IAnalysisLogger Logger { get; set; }

        public PropertyBag Policy { get; set; }

        public IRuleDescriptor Rule { get; set; }

        public Exception TargetLoadException { get; set; }

        public Uri TargetUri { get; set; }

        public string MimeType { get; set; }

        public RuntimeConditions RuntimeErrors { get; set; }

        public void Dispose()
        {
        }
    }
}
