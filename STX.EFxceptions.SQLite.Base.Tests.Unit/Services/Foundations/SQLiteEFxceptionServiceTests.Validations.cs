// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using Xunit;

namespace STX.EFxceptions.SQLite.Base.Tests.Unit.Services.Foundations
{
    public partial class SQLiteEFxceptionServiceTests
    {
        [Fact]
        public void ShouldThrowDbUpdateExceptionIfSQLiteExceptionsIsNull()
        {
            // given
            var dbUpdateException = new DbUpdateException(null, default(Exception));
            DbUpdateException expectedDbUpdateException = dbUpdateException;

            // when 
            DbUpdateException actualDbUpdateException =
                Assert.Throws<DbUpdateException>(() =>
                    this.sqliteEFxceptionService
                        .ThrowMeaningfulException(dbUpdateException));
            // then
            actualDbUpdateException.Should()
                .BeEquivalentTo(
                expectation: expectedDbUpdateException,
                config: options => options
                    .Excluding(ex => ex.TargetSite)
                    .Excluding(ex => ex.StackTrace)
                    .Excluding(ex => ex.Source)
                    .Excluding(ex => ex.InnerException.TargetSite)
                    .Excluding(ex => ex.InnerException.StackTrace)
                    .Excluding(ex => ex.InnerException.Source));

            this.sqliteErrorBrokerMock.Verify(broker =>
                broker.GetErrorCode(It.IsAny<SqliteException>()),
                    Times.Never);

            this.sqliteErrorBrokerMock.VerifyNoOtherCalls();
        }
    }
}
