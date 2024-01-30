// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX.EFxceptions.SQLite.Base.Models.Exceptions
{
    public class InvalidObjectNameSQLiteException : Exception
    {
        public InvalidObjectNameSQLiteException(string message) : base(message) { }
    }
}
