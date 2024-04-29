// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using STX.EFxceptions.Abstractions.Models.Exceptions;
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

            SqliteException foreignKeyConstraintConflictExceptionThrown =
                CreateSQLiteException(
                    message: randomErrorMessage,
                    errorCode: sqlForeignKeyConstraintConflictErrorCode);

            var dbUpdateException = new DbUpdateException(
                message: randomErrorMessage,
                innerException: foreignKeyConstraintConflictExceptionThrown);

            DbUpdateException expectedDbUpdateException = dbUpdateException;

            this.sqliteErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(foreignKeyConstraintConflictExceptionThrown))
                    .Returns(sqlForeignKeyConstraintConflictErrorCode);

            // when
            DbUpdateException actualDbUpdateException =
                Assert.Throws<DbUpdateException>(() => this.sqliteEFxceptionService
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


            this.sqliteErrorBrokerMock.Verify(broker => broker
                .GetErrorCode(foreignKeyConstraintConflictExceptionThrown), Times.Once());

            sqliteErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowInvalidColumnNameException()
        {
            // given
            int sqlInvalidColumnNameErrorCode = 207;
            string randomSqliteExceptionMessage = CreateRandomErrorMessage();

            SqliteException invalidColumnNameExceptionThrown =
                CreateSQLiteException(
                    message: randomSqliteExceptionMessage,
                    errorCode: sqlInvalidColumnNameErrorCode);

            string randomDbUpdateExceptionMessage = CreateRandomErrorMessage();

            DbUpdateException dbUpdateExceptionThrown = new DbUpdateException(
                message: randomDbUpdateExceptionMessage,
                innerException: invalidColumnNameExceptionThrown);

            var ivalidColumnNameSqliteException =
                new InvalidColumnNameSQLiteException(
                    message: invalidColumnNameExceptionThrown.Message);

            var expectedInvalidColumnNameException =
                new InvalidColumnNameException(
                    message: ivalidColumnNameSqliteException.Message,
                    innerException: ivalidColumnNameSqliteException);

            this.sqliteErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(invalidColumnNameExceptionThrown))
                    .Returns(sqlInvalidColumnNameErrorCode);

            // when
            InvalidColumnNameException actualInvalidColumnNameException =
                Assert.Throws<InvalidColumnNameException>(() =>
                    this.sqliteEFxceptionService.ThrowMeaningfulException(dbUpdateExceptionThrown));
            // then
            actualInvalidColumnNameException.Should()
                .BeEquivalentTo(
                    expectation: expectedInvalidColumnNameException,
                    config: options => options
                        .Excluding(ex => ex.TargetSite)
                        .Excluding(ex => ex.StackTrace)
                        .Excluding(ex => ex.Source)
                        .Excluding(ex => ex.InnerException.TargetSite)
                        .Excluding(ex => ex.InnerException.StackTrace)
                        .Excluding(ex => ex.InnerException.Source));

            this.sqliteErrorBrokerMock.Verify(broker => broker
                .GetErrorCode(invalidColumnNameExceptionThrown), Times.Once());

            sqliteErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowInvalidObjectNameException()
        {
            // given
            int sqlInvalidObjectNameErrorCode = 208;
            string randomSqliteExceptionMessage = CreateRandomErrorMessage();

            SqliteException invalidObjectNameExceptionThrown =
                CreateSQLiteException(
                    message: randomSqliteExceptionMessage,
                    errorCode: sqlInvalidObjectNameErrorCode);

            string randomDbUpdateExceptionMessage = CreateRandomErrorMessage();

            var dbUpdateException = new DbUpdateException(
                message: randomDbUpdateExceptionMessage,
                innerException: invalidObjectNameExceptionThrown);

            var invalidObjectNameSqliteException =
                new InvalidObjectNameSQLiteException(
                    message: invalidObjectNameExceptionThrown.Message);

            var expectedInvalidObjectNameException =
                new InvalidObjectNameException(
                    message: invalidObjectNameSqliteException.Message,
                    innerException: invalidObjectNameSqliteException);

            this.sqliteErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(invalidObjectNameExceptionThrown))
                    .Returns(sqlInvalidObjectNameErrorCode);

            // when
            InvalidObjectNameException actualInvalidObjectNameException =
                Assert.Throws<InvalidObjectNameException>(() =>
                    this.sqliteEFxceptionService.ThrowMeaningfulException(dbUpdateException));

            // then
            actualInvalidObjectNameException.Should()
                .BeEquivalentTo(
                expectation: expectedInvalidObjectNameException,
                config: options => options
                    .Excluding(ex => ex.TargetSite)
                    .Excluding(ex => ex.StackTrace)
                    .Excluding(ex => ex.Source)
                    .Excluding(ex => ex.InnerException.TargetSite)
                    .Excluding(ex => ex.InnerException.StackTrace)
                    .Excluding(ex => ex.InnerException.Source));

            this.sqliteErrorBrokerMock.Verify(broker => broker
                .GetErrorCode(invalidObjectNameExceptionThrown), Times.Once());

            sqliteErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowForeignKeyConstraintConflictException()
        {
            // given
            int sqlForeignKeyConstraintConflictErrorCode = 547;
            string randomSqliteExceptionMessage = CreateRandomErrorMessage();

            SqliteException foreignKeyConstraintConflictSqliteExceptionThrown =
                CreateSQLiteException(
                    message: randomSqliteExceptionMessage,
                    errorCode: sqlForeignKeyConstraintConflictErrorCode);

            string randomDbUpdateExceptionMessage = CreateRandomErrorMessage();

            var dbUpdateException = new DbUpdateException(
                message: randomDbUpdateExceptionMessage,
                innerException: foreignKeyConstraintConflictSqliteExceptionThrown);

            var foreignKeyConstraintConflictSqliteException =
                new ForeignKeyConstraintConflictSQLiteException(
                    message: foreignKeyConstraintConflictSqliteExceptionThrown.Message);

            var expectedForeignKeyConstraintConflictException =
                new ForeignKeyConstraintConflictException(
                    message: foreignKeyConstraintConflictSqliteException.Message,
                    innerException: foreignKeyConstraintConflictSqliteException);

            this.sqliteErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(foreignKeyConstraintConflictSqliteExceptionThrown))
                    .Returns(sqlForeignKeyConstraintConflictErrorCode);

            // when
            var actualForeignKeyConstraintConflictException =
                Assert.Throws<ForeignKeyConstraintConflictException>(() =>
                    this.sqliteEFxceptionService.ThrowMeaningfulException(dbUpdateException));

            // then
            actualForeignKeyConstraintConflictException.Should()
                .BeEquivalentTo(
                expectation: expectedForeignKeyConstraintConflictException,
                config: options => options
                    .Excluding(ex => ex.TargetSite)
                    .Excluding(ex => ex.StackTrace)
                    .Excluding(ex => ex.Source)
                    .Excluding(ex => ex.InnerException.TargetSite)
                    .Excluding(ex => ex.InnerException.StackTrace)
                    .Excluding(ex => ex.InnerException.Source));

            this.sqliteErrorBrokerMock.Verify(broker => broker
                .GetErrorCode(foreignKeyConstraintConflictSqliteExceptionThrown), Times.Once());

            sqliteErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowDuplicateKeyWithUniqueIndexException()
        {
            // given
            int sqlDuplicateKeyErrorCode = 2601;
            string randomSqliteExceptionMessage = CreateRandomErrorMessage();

            SqliteException duplicateKeyWithUniqueIndexSqliteExceptionThrown =
                CreateSQLiteException(
                    message: randomSqliteExceptionMessage,
                    errorCode: sqlDuplicateKeyErrorCode);

            string randomDbUpdateExceptionMessage = CreateRandomErrorMessage();

            var dbUpdateException = new DbUpdateException(
                message: randomDbUpdateExceptionMessage,
                innerException: duplicateKeyWithUniqueIndexSqliteExceptionThrown);

            var duplicateKeyWithUniqueIndexSqliteException =
                new DuplicateKeyWithUniqueIndexSQLiteException(
                    message: duplicateKeyWithUniqueIndexSqliteExceptionThrown.Message);

            var expectedDuplicateKeyWithUniqueIndexException =
                new DuplicateKeyWithUniqueIndexException(
                    message: duplicateKeyWithUniqueIndexSqliteException.Message,
                    innerException: duplicateKeyWithUniqueIndexSqliteException);

            this.sqliteErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(duplicateKeyWithUniqueIndexSqliteExceptionThrown))
                    .Returns(sqlDuplicateKeyErrorCode);

            // when 
            var actualDuplicateKeyWithUniqueIndexException =
                Assert.Throws<DuplicateKeyWithUniqueIndexException>(() =>
                    this.sqliteEFxceptionService.ThrowMeaningfulException(dbUpdateException));

            // then
            actualDuplicateKeyWithUniqueIndexException.Should()
                .BeEquivalentTo(
                expectation: expectedDuplicateKeyWithUniqueIndexException,
                config: options => options
                    .Excluding(ex => ex.TargetSite)
                    .Excluding(ex => ex.StackTrace)
                    .Excluding(ex => ex.Source)
                    .Excluding(ex => ex.InnerException.TargetSite)
                    .Excluding(ex => ex.InnerException.StackTrace)
                    .Excluding(ex => ex.InnerException.Source));

            this.sqliteErrorBrokerMock.Verify(broker => broker
                .GetErrorCode(duplicateKeyWithUniqueIndexSqliteExceptionThrown), Times.Once());

            sqliteErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowDuplicateKeyException()
        {
            // given
            int sqlDuplicateKeyErrorCode = 2627;
            string randomSqliteExceptionMessage = CreateRandomErrorMessage();

            SqliteException duplicateKeySqliteExceptionThrown = CreateSQLiteException(
                message: randomSqliteExceptionMessage,
                errorCode: sqlDuplicateKeyErrorCode);

            string randomDbUpdateExceptionMessage = CreateRandomErrorMessage();

            var dbUpdateException = new DbUpdateException(
                message: randomDbUpdateExceptionMessage,
                innerException: duplicateKeySqliteExceptionThrown);

            var duplicateKeySqliteException =
                new DuplicateKeySQLiteException(
                    message: duplicateKeySqliteExceptionThrown.Message);

            var expectedDuplicateKeyException =
                new DuplicateKeyException(
                    message: duplicateKeySqliteException.Message,
                    innerException: duplicateKeySqliteException);

            this.sqliteErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(duplicateKeySqliteExceptionThrown))
                    .Returns(sqlDuplicateKeyErrorCode);

            // when
            var actualDuplicateKeyException =
                Assert.Throws<DuplicateKeyException>(() =>
                    this.sqliteEFxceptionService.ThrowMeaningfulException(dbUpdateException));

            // then
            actualDuplicateKeyException.Should()
                .BeEquivalentTo(
                expectation: expectedDuplicateKeyException,
                config: options => options
                    .Excluding(ex => ex.TargetSite)
                    .Excluding(ex => ex.StackTrace)
                    .Excluding(ex => ex.Source)
                    .Excluding(ex => ex.InnerException.TargetSite)
                    .Excluding(ex => ex.InnerException.StackTrace)
                    .Excluding(ex => ex.InnerException.Source));

            this.sqliteErrorBrokerMock.Verify(broker => broker
                .GetErrorCode(duplicateKeySqliteExceptionThrown), Times.Once());

            sqliteErrorBrokerMock.VerifyNoOtherCalls();
        }
    }
}
