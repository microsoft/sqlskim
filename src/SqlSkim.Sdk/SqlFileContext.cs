// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;

using Microsoft.CodeAnalysis.Sarif.Driver.Sdk;
using Microsoft.CodeAnalysis.Sarif.Sdk;

namespace Microsoft.CodeAnalysis.Sql
{
    public class SqlFileContext : IAnalysisContext
    {
        private static HashSet<string> ValidFileExtensions = new HashSet<string>(
            new string[] { ".sql" }, StringComparer.OrdinalIgnoreCase);
    
        public bool IsValidAnalysisTarget
        {
            get
            {
                return ValidFileExtensions.Contains(Path.GetExtension(this.TargetUri.LocalPath));
            }
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
