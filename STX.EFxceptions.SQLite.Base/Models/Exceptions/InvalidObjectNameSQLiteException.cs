// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;

namespace STX.EFxceptions.SQLite.Base.Models.Exceptions
{
    public class InvalidObjectNameSQLiteException : DbUpdateException
    {
        public InvalidObjectNameSQLiteException(string message) : base(message) { }
    }
}
