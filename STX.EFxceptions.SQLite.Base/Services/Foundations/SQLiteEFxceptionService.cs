// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.Interfaces.Brokers.DbErrorBroker;

namespace STX.EFxceptions.SQLite.Base.Services.Foundations
{
    public partial class SQLiteEFxceptionService : ISQLiteEFxceptionService
    {
        private readonly IDbErrorBroker<SqliteException> sqliteErrorBroker;

        public SQLiteEFxceptionService(IDbErrorBroker<SqliteException> sqliteErrorBroker) =>
            this.sqliteErrorBroker = sqliteErrorBroker;

        public void ThrowMeaningfulException(DbUpdateException dbUpdateException)
        {
            ValidateInnerException(dbUpdateException);
        }
    }
}
