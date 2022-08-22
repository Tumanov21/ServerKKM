using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.CheckComponents
{
    /// <summary>
    /// Данные агента в чеке
    /// </summary>
    [Serializable]
    [DataContract]
    public class CheckAgentData
    {
        /// <summary>
        /// Операция платежного агента
        /// </summary>
        [DataMember]
        public string PayingAgentOperation { get; set; }
        /// <summary>
        /// Телефон платежного агента
        /// </summary>
        [DataMember]
        public string PayingAgentPhone { get; set; }
        /// <summary>
        /// Телефон оператора по приему платежей
        /// </summary>
        [DataMember]
        public string ReceivePaymentsOperatorPhone { get; set; }
        /// <summary>
        /// Телефон оператора перевода
        /// </summary>
        [DataMember]
        public string MoneyTransferOperatorPhone { get; set; }
        /// <summary>
        /// Наименование оператора перевода
        /// </summary>
        [DataMember]
        public string MoneyTransferOperatorName { get; set; }
        /// <summary>
        /// Адрес оператора перевода
        /// </summary>
        [DataMember]
        public string MoneyTransferOperatorAddress { get; set; }
        /// <summary>
        /// ИНН оператора перевода
        /// </summary>
        [DataMember]
        public string MoneyTransferOperatorVATIN { get; set; }
    }
}
