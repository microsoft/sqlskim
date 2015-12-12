// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Xunit;

namespace Microsoft.CodeAnalysis.Sql
{
    public class SqlSkimTests
    {
        [Fact]
        public void Driver_MainSucceeds()
        {
            Assert.Equal(0, SqlSkim.Main(null));
        }
    }
}
