// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.SQLite.Tests.Acceptance.Models.Clients;

namespace STX.EFxceptions.SQLite.Tests.Acceptance
{
    public class MyEFxceptionsContext : EFxceptionsContext
    {
        public MyEFxceptionsContext(DbContextOptions<EFxceptionsContext> options)
            :base(options)
        { }

        public DbSet<Client> Clients { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
