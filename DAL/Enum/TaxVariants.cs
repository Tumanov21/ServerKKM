using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enum
{
    public enum TaxVariants
    {
        ОСН = 0,
        УСН = 1,
        УСНД_Р = 2,
        ЕНВД = 3,
        ЕСН = 4,
        ПСН = 5,

        /// <summary>
        /// Не используется
        /// </summary>
        None = 999
    }
}
