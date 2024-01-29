// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Moq;
using STX.EFxceptions.SQLite.Base.Brokers.DbErrorBroker;
using STX.EFxceptions.SQLite.Base.Services.Foundations;

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
    }
}
