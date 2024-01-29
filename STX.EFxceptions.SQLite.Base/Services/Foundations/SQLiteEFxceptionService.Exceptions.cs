﻿using STX.EFxceptions.SQLite.Base.Models.Exceptions;

namespace STX.EFxceptions.SQLite.Base.Services.Foundations
{
    public partial class SQLiteEFxceptionService
    {
        private void ConvertAndThrowMeaningfulException(int sqliteErrorCode, string message)
        {
            switch (sqliteErrorCode)
            {
                case 207:
                    throw new InvalidColumnNameException(message);
                case 208:
                    throw new InvalidObjectNameSqliteException(message);
                case 547:
                    throw new ForeignKeyConstraintConflictSqliteException(message);
                case 2601:
                    throw new DuplicateKeyWithUniqueIndexSqliteException(message);
                case 2627:
                    throw new DuplicateKeySqliteException(message);
            }
        }
    }
}