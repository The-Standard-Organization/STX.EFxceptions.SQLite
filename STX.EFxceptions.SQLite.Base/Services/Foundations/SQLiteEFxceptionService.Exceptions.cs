using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX.EFxceptions.SQLite.Base.Models.Exceptions;

namespace STX.EFxceptions.SQLite.Base.Services.Foundations
{
    public partial class SQLiteEFxceptionService
    {
        private void ConvertAndThrowMeaningfulException(int sqliteErrorCode, string message)
        {
            switch(sqliteErrorCode)
            {
                case 207:
                    throw new InvalidColumnNameException(message);
            }
        }
    }
}
