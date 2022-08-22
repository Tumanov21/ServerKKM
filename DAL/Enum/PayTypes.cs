using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enum
{
    /// <summary>
    /// Типы оплат
    /// </summary>
    [DataContract]
    public enum PayTypes
    {
        [EnumMember]
        Наличные = 0,

        [EnumMember]
        Электронными = 1,

        [EnumMember]
        Кредит = 2,

        [EnumMember]
        Предоплата = 3,

        [EnumMember]
        Представление = 4,

        [EnumMember]
        ВикиПредоплата = 13,

        [EnumMember]
        ВикиКредит = 14,

        [EnumMember]
        ВикиПредставление = 15,
    }
}
