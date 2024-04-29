using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.Abstractions.Models.Exceptions;
using STX.EFxceptions.SQLite.Base.Models.Exceptions;

namespace STX.EFxceptions.SQLite.Base.Services.Foundations
{
    public partial class SQLiteEFxceptionService
    {
        public delegate void ReturningExceptionFunction();

        public void TryCatch(ReturningExceptionFunction returningExceptionFunction)
        {
            try
            {
                returningExceptionFunction();
            }
            catch (InvalidColumnNameSQLiteException ivalidColumnNameSQLiteException)
            {
                throw new InvalidColumnNameException(
                    message: ivalidColumnNameSQLiteException.Message,
                    innerException: ivalidColumnNameSQLiteException);
            }
            catch (InvalidObjectNameSQLiteException invalidObjectNameSQLiteException)
            {
                throw new InvalidObjectNameException(
                    message: invalidObjectNameSQLiteException.Message,
                    innerException: invalidObjectNameSQLiteException);
            }
            catch (ForeignKeyConstraintConflictSQLiteException foreignKeyConstraintConflictSQLiteException)
            {
                throw new ForeignKeyConstraintConflictException(
                    message: foreignKeyConstraintConflictSQLiteException.Message,
                    innerException: foreignKeyConstraintConflictSQLiteException);
            }
            catch (DuplicateKeyWithUniqueIndexSQLiteException duplicateKeyWithUniqueIndexSQLiteException)
            {
                throw new DuplicateKeyWithUniqueIndexException(
                    message: duplicateKeyWithUniqueIndexSQLiteException.Message,
                    innerException: duplicateKeyWithUniqueIndexSQLiteException);
            }
            catch (DuplicateKeySQLiteException duplicateKeySQLiteException)
            {
                throw new DuplicateKeyException(
                    message: duplicateKeySQLiteException.Message,
                    innerException: duplicateKeySQLiteException);
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        private void ConvertAndThrowMeaningfulException(int sqlErrorCode, string message)
        {
            switch (sqlErrorCode)
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
