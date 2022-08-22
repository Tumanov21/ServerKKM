using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.CheckComponents
{
    /// <summary>
    /// Класс оплаты
    /// </summary>
    [Serializable]
    [DataContract]
    public class Payment
    {
        /// <summary>
        /// Сумма оплаты
        /// </summary>
        [DataMember]
        public decimal Summ;

        /// <summary>
        /// 0 - nal
        /// 1 -
        /// </summary>
        //[DataMember]
        //[Obsolete]
        //public PayTypes TypeClose;

        /// <summary>
        /// Скидка на вид оплаты
        /// </summary>
        [DataMember]
        [Obsolete]
        public decimal Discount;

        [DataMember]
        [Obsolete]
        public string BeforePrint;

        [DataMember]
        [Obsolete]
        public string AfterPrint;
    }
}
