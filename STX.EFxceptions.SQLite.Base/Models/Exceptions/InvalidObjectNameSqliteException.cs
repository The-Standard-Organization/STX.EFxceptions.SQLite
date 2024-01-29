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
    public class InvalidObjectNameSqliteException : Exception
    {
        public InvalidObjectNameSqliteException(string message) : base(message) { }
    }
}
