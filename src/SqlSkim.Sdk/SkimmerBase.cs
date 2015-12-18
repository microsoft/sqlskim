// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.CodeAnalysis.Sarif.Driver.Sdk;

namespace Microsoft.CodeAnalysis.Sql.Sdk
{
    public abstract class SqlSkimmerBase : SkimmerBase<SqlFileContext>, ISqlSkimmer
    {
    }
}
