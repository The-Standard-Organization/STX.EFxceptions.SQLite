// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Data.Sqlite;
using STX.EFxceptions.Interfaces.Brokers.DbErrorBroker;

namespace STX.EFxceptions.SQLite.Base.Brokers.DbErrorBroker
{
    public interface ISQLiteErrorBroker : IDbErrorBroker<SqliteException>
    { }
}
