// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.SQLite.Base.Models.Exceptions;
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
        
        [Fact]
        public void ShouldThrowInvalidColumnNameException()
        {
            // given
            int sqlInvalidColumnNameErrorCode = 207;
            string randomErrorMessage = CreateRandomErrorMessage();
            SqliteException invalidColumnNameException = CreateSQLiteException();

            var dbUpdateException = new DbUpdateException(
                message: randomErrorMessage,
                innerException: invalidColumnNameException);

            this.sqliteErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(invalidColumnNameException))
                    .Returns(sqlInvalidColumnNameErrorCode);

            // when . then
            Assert.Throws<InvalidColumnNameException>(() =>
                this.sqliteEFxceptionService.ThrowMeaningfulException(dbUpdateException));
        }
        
        [Fact]
        public void ShouldThrowInvalidObjectNameSqliteException()
        {
            // given
            int sqlInvalidObjectNameErrorCode = 208;
            string randomErrorMessage = CreateRandomErrorMessage();
            SqliteException invalidObjectNameException = CreateSQLiteException();

            var dbUpdateException = new DbUpdateException(
                message: randomErrorMessage,
                innerException: invalidObjectNameException);

            this.sqliteErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(invalidObjectNameException))
                    .Returns(sqlInvalidObjectNameErrorCode);

            // when . then
            Assert.Throws<InvalidObjectNameSqliteException>(() =>
                this.sqliteEFxceptionService.ThrowMeaningfulException(dbUpdateException));
        }
        
        [Fact]
        public void ShouldThrowForeignKeyConstraintConflictSqliteException()
        {
            // given
            int sqlForeignKeyConstraintConflictErrorCode = 547;
            string randomErrorMessage = CreateRandomErrorMessage();
            SqliteException foreignKeyConstraintConflictException = CreateSQLiteException();

            var dbUpdateException = new DbUpdateException(
                message: randomErrorMessage,
                innerException: foreignKeyConstraintConflictException);

            this.sqliteErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(foreignKeyConstraintConflictException))
                    .Returns(sqlForeignKeyConstraintConflictErrorCode);

            // when . then
            Assert.Throws<ForeignKeyConstraintConflictSqliteException>(() =>
                this.sqliteEFxceptionService.ThrowMeaningfulException(dbUpdateException));
        }
    }
}
