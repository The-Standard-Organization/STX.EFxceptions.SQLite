using STX.EFxceptions.SQLite.Base.Models.Exceptions;

namespace STX.EFxceptions.SQLite.Base.Services.Foundations
{
    public partial class SQLiteEFxceptionService
    {
        private void ConvertAndThrowMeaningfulException(int sqliteErrorCode, string message)
        {
            switch (sqliteErrorCode)
            {
                case 207:
                    throw new InvalidColumnNameSQLiteException(message);
                case 208:
                    throw new InvalidObjectNameSQLiteException(message);
                case 547:
                    throw new ForeignKeyConstraintConflictSQLiteException(message);
                case 2601:
                    throw new DuplicateKeyWithUniqueIndexSQLiteException(message);
                case 2627:
                    throw new DuplicateKeySQLiteException(message);
            }
        }
    }
}
