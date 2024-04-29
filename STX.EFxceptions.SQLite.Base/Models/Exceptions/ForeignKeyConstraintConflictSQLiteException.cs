// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;

namespace STX.EFxceptions.SQLite.Base.Models.Exceptions
{
    public class ForeignKeyConstraintConflictSQLiteException : DbUpdateException
    {
        public ForeignKeyConstraintConflictSQLiteException(string message) : base(message) { }
    }
}
