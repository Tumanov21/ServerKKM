using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.CheckComponents
{
    /// <summary>
    /// Данные для отображения QR кода чека
    /// </summary>
    [Serializable]
    [DataContract]
    public class QRData
    {
        /// <summary>
        /// Дата t=20210101T1019
        /// </summary>
        [DataMember]
        public DateTime Date { get; set; }

        /// <summary>
        /// Сумма чека s=
        /// </summary>
        [DataMember]
        public decimal Amount { get; set; }

        /// <summary>
        /// Фискальный накопитель fn=
        /// </summary>
        [DataMember]
        public string Fn { get; set; }

        /// <summary>
        /// Фискальный документ, номер i=
        /// </summary>
        [DataMember]
        public int Fd { get; set; }

        /// <summary>
        /// Фискальный признак fp=
        /// </summary>
        [DataMember]
        public string Fp { get; set; }

        /// <summary>
        /// Тип чека n=
        /// </summary>
        [DataMember]
        public int N { get; set; }
    }
}

