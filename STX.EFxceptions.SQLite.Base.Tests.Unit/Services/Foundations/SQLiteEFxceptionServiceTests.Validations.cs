// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace STX.EFxceptions.SQLite.Base.Tests.Unit.Services.Foundations
{
    public partial class SQLiteEFxceptionServiceTests
    {
        [Fact]
        public void ShouldThrowDbUpdateExceptionIfSQLiteExceptionsIsNull()
        {
            // given
            DbUpdateException dbUpdateException =
                new DbUpdateException(null, default(Exception));

            // when
            Assert.Throws<DbUpdateException>(() => this.sqliteEFxceptionService
                .ThrowMeaningfulException(dbUpdateException));

            // then
            this.sqliteErrorBrokerMock.Verify(broker =>
                broker.GetErrorCode(It.IsAny<SqliteException>()), Times.Never);
        }
    }
}
