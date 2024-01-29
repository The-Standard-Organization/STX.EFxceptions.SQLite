// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace STX.EFxceptions.SQLite.Base.Tests.Unit.Services.Foundations
{
    public partial class SQLiteEFxceptionServiceTests
    {
        [Fact]
        public void ShouldThrowDbUpdateExceptionIfErrorCodeIsNotRecognized()
        {
            // given
            int sqlForeignKeyConstraintConflictErrorCode = 0000;
            string randomErrorMessage = CreateRandomErrorMessage();
            SqliteException foreignKeyConstraintConflictException = CreateSQLiteException();

            var dbUpdateException = new DbUpdateException(
                message: randomErrorMessage,
                innerException: foreignKeyConstraintConflictException);

            this.sqliteErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(foreignKeyConstraintConflictException))
                    .Returns(sqlForeignKeyConstraintConflictErrorCode);

            // when . then
            Assert.Throws<DbUpdateException>(() =>
                this.sqliteEFxceptionService.ThrowMeaningfulException(dbUpdateException));
        }
    }
}
