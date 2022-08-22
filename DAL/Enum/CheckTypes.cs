using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enum
{
    [DataContract]
    public enum CheckTypes
    {
        [EnumMember]
        ОтменаЧека = 0,

        /// <summary>
        /// Приход
        /// </summary>
        [EnumMember]
        Продажа = 1,

        /// <summary>
        /// Возврат прихода
        /// </summary>
        [EnumMember]
        Возврат = 2,

        [EnumMember]
        Аннулирование = 3,

        /// <summary>
        /// Расход
        /// </summary>
        [EnumMember]
        Покупка = 4,

        /// <summary>
        /// Возврат покупки
        /// </summary>
        [EnumMember]
        ВозвратПокупки = 5,

        [EnumMember]
        АннулированиеПокупки = 6,

        [EnumMember]
        ЧекКоррекцииПрихода = 7,

        [EnumMember]
        ЧекКоррекцииВозвратаПрихода = 8,

        [EnumMember]
        ЧекКоррекцииРасхода = 9,

        [EnumMember]
        ЧекКоррекцииВозвратаРасхода = 10,

        [EnumMember]
        ВСчетСотрудника = 11,
        [EnumMember]
        Any = 100
    }
}
