using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enum
{
    /// <summary>
    /// Признаки способа расчета.
    /// ФФД 1.0.5
    /// </summary>
    [DataContract]
    public enum PaymentModes
    {
        [EnumMember]
        НеПрименяется = 0,

        /// <summary>
        /// Предоплата
        /// Полная предварительная оплата до момента передачи предмета расчета
        /// </summary>
        [EnumMember]
        ПредоплатаПолная = 1,

        /// <summary>
        /// Частичная предварительная оплата до момента передачи предмета расчета
        /// </summary>
        [EnumMember]
        ПредоплатаЧастичная,

        /// <summary>
        /// Аванс
        /// </summary>
        [EnumMember]
        Аванс,

        /// <summary>
        /// Полная оплата, в том числе с учетом аванса (предварительной оплаты) в момент передачи предмета расчета
        /// </summary>
        [EnumMember]
        ПередачаСПолнойОплатой,

        /// <summary>
        /// Частичная оплата предмета расчета в момент его передачи с последующей оплатой в кредит
        /// </summary>
        [EnumMember]
        ПередачСЧастичнойОплатой,

        /// <summary>
        /// Передача предмета расчета без его оплаты в момент его передачи с последующей оплатой в кредит
        /// </summary>
        [EnumMember]
        ПередачабезОплаты,

        /// <summary>
        /// Оплата предмета расчета после его передачи с оплатой в кредит (оплата кредита)
        /// </summary>
        [EnumMember]
        ОплатаКредита,
    }
}
