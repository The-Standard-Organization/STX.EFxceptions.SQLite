﻿// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;

namespace STX.EFxceptions.SQLite.Base.Models.Exceptions
{
    public class ForeignKeyConstraintConflictSQLiteException : Exception
    {
        public ForeignKeyConstraintConflictSQLiteException(string message) : base(message) { }
    }
}
