// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;

namespace STX.EFxceptions.SQLite.Base.Models.Exceptions
{
    public class DuplicateKeySqliteException : Exception
    {
        public DuplicateKeySqliteException(string message) : base(message) { }
    }
}
