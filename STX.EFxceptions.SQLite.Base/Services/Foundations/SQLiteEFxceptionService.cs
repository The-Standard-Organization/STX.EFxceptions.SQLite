﻿// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.Abstractions.Brokers.DbErrorBroker;

namespace STX.EFxceptions.SQLite.Base.Services.Foundations
{
    public partial class SQLiteEFxceptionService : ISQLiteEFxceptionService
    {
        private readonly IDbErrorBroker<SqliteException> sqliteErrorBroker;

        public SQLiteEFxceptionService(IDbErrorBroker<SqliteException> sqliteErrorBroker) =>
            this.sqliteErrorBroker = sqliteErrorBroker;

        public void ThrowMeaningfulException(DbUpdateException dbUpdateException) =>
        TryCatch(() =>
        {
            ValidateInnerException(dbUpdateException);
            SqliteException sqliteException = GetSqliteException(dbUpdateException);
            int sqliteErrorCode = this.sqliteErrorBroker.GetErrorCode(sqliteException);
            ConvertAndThrowMeaningfulException(sqliteErrorCode, sqliteException.Message);
            throw dbUpdateException;
        });

        private SqliteException GetSqliteException(Exception exception) =>
            (SqliteException)exception.InnerException;
    }
}
