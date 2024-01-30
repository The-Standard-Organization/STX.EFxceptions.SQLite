// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Runtime.Serialization;
using Microsoft.Data.Sqlite;
using Moq;
using STX.EFxceptions.SQLite.Base.Brokers.DbErrorBroker;
using STX.EFxceptions.SQLite.Base.Services.Foundations;
using Tynamix.ObjectFiller;

namespace STX.EFxceptions.SQLite.Base.Tests.Unit.Services.Foundations
{
    public partial class SQLiteEFxceptionServiceTests
    {
        private readonly Mock<ISQLiteErrorBroker> sqliteErrorBrokerMock;
        private readonly ISQLiteEFxceptionService sqliteEFxceptionService;

        public SQLiteEFxceptionServiceTests()
        {
            this.sqliteErrorBrokerMock = new Mock<ISQLiteErrorBroker>();

            this.sqliteEFxceptionService = new SQLiteEFxceptionService(
                sqliteErrorBroker: this.sqliteErrorBrokerMock.Object);
        }

        private string CreateRandomErrorMessage() => new MnemonicString().GetValue();

        private SqliteException CreateSQLiteException() =>
            FormatterServices.GetSafeUninitializedObject(typeof(SqliteException)) as SqliteException;
    }
}
