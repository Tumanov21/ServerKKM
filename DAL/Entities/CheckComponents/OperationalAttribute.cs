using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.CheckComponents
{
    /// <summary>
    /// Операционный реквизит чека
    /// </summary>
    [DataContract]
    [Serializable]
    public class OperationalAttribute
    {
        /// <summary>
        /// Дата, время операции
        /// </summary>
        [DataMember]
        public string DateTime { get; set; }
        /// <summary>
        /// Идентификатор операции
        /// </summary>
        [DataMember]
        public int OperationID { get; set; }
        /// <summary>
        /// Данные операции
        /// </summary>
        [DataMember]
        public string OperationData { get; set; }
    }

}
