﻿// ----------------------------------------------------------------------------------
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
            Assert.Throws<InvalidColumnNameSQLiteException>(() =>
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
            Assert.Throws<InvalidObjectNameSQLiteException>(() =>
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
            Assert.Throws<ForeignKeyConstraintConflictSQLiteException>(() =>
                this.sqliteEFxceptionService.ThrowMeaningfulException(dbUpdateException));
        }

        [Fact]
        public void ShouldThrowDuplicateKeyWithUniqueIndexSqliteException()
        {
            // given
            int sqlDuplicateKeyWithUniqueIndexErrorCode = 2601;
            string randomErrorMessage = CreateRandomErrorMessage();
            SqliteException sqlDuplicateKeyWithUniqueIndexException = CreateSQLiteException();

            var dbUpdateException = new DbUpdateException(
                message: randomErrorMessage,
                innerException: sqlDuplicateKeyWithUniqueIndexException);

            this.sqliteErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(sqlDuplicateKeyWithUniqueIndexException))
                    .Returns(sqlDuplicateKeyWithUniqueIndexErrorCode);

            // when . then
            Assert.Throws<DuplicateKeyWithUniqueIndexSQLiteException>(() =>
                this.sqliteEFxceptionService.ThrowMeaningfulException(dbUpdateException));
        }

        [Fact]
        public void ShouldThrowDuplicateKeySqliteException()
        {
            // given
            int sqlDuplicateKeyErrorCode = 2627;
            string randomErrorMessage = CreateRandomErrorMessage();
            SqliteException sqlDuplicateKeyException = CreateSQLiteException();

            var dbUpdateException = new DbUpdateException(
                message: randomErrorMessage,
                innerException: sqlDuplicateKeyException);

            this.sqliteErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(sqlDuplicateKeyException))
                    .Returns(sqlDuplicateKeyErrorCode);

            // when . then
            Assert.Throws<DuplicateKeySQLiteException>(() =>
                this.sqliteEFxceptionService.ThrowMeaningfulException(dbUpdateException));
        }
    }
}
