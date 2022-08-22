using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enum
{
    /// <summary>
    /// Типы документов
    /// </summary>
    [DataContract]
    public enum DocTypes : byte
    {
        [EnumMember]
        Чек,

        [EnumMember]
        Отчет,

        [EnumMember]
        ВнесениеВыемка,

        [EnumMember]
        ОтменаЧека,

        [EnumMember]
        ОткрытьЯщик,

        [EnumMember]
        ЗаказПоТовару,

        [EnumMember]
        Текст,

        [EnumMember]
        Штрихкод,

        [EnumMember]
        ОткрытьСмену
    }
}
