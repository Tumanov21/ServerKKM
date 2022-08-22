using DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Ext
{
    public static class ErrorExt
    {
        /// <summary>
        /// Получить представление ошибки с проблема вместо подчеркиваний
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static string GetDescription(this Error error)
        {
            return error.ToString().Replace("_", " ");
        }
    }
}
