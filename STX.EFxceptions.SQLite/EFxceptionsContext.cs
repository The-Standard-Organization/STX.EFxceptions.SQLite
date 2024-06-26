﻿// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.Core;
using STX.EFxceptions.Abstractions.Brokers.DbErrorBroker;
using STX.EFxceptions.Abstractions.Services.EFxceptions;
using STX.EFxceptions.SQLite.Base.Brokers.DbErrorBroker;
using STX.EFxceptions.SQLite.Base.Services.Foundations;

namespace STX.EFxceptions.SQLite
{
    public abstract class EFxceptionsContext : DbContextBase<SqliteException>
    {
        protected EFxceptionsContext()
            : base() { }
            
        public EFxceptionsContext(DbContextOptions<EFxceptionsContext> options)
            : base(options) { }

        protected override IDbErrorBroker<SqliteException> CreateErrorBroker() =>
            new SQLiteErrorBroker();

        protected override IEFxceptionService CreateEFxceptionService(
            IDbErrorBroker<SqliteException> errorBroker)
        {
            return new SQLiteEFxceptionService(errorBroker);
        }
    }
}
