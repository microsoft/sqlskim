// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;

using Microsoft.CodeAnalysis.Sarif.Driver.Sdk;
using Microsoft.CodeAnalysis.Sarif.Sdk;

namespace Microsoft.CodeAnalysis.Sql.Sdk
{
    public interface ISqlSkimmer : ISkimmer<SqlFileContext>, IRuleDescriptor
    {
        IEnumerable<Type> Types { get; }
    }
}
