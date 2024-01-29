// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Data.Sqlite;

namespace STX.EFxceptions.SQLite.Base.Brokers.DbErrorBroker
{
    public class SQLiteErrorBroker : ISQLiteErrorBroker
    {
        public int GetErrorCode(SqliteException sqlitException) =>
            sqlitException.ErrorCode;
    }
}
