using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.CheckComponents
{
    /// <summary>
    /// Отраслевой реквизит предмета расчета
    /// </summary>
    [DataContract]
    [Serializable]
    public class IndustryAttribute
    {
        /// <summary>
        /// Идентификатор ФОИВ
        /// </summary>
        [DataMember]
        public string IdentifierFOIV { get; set; }
        /// <summary>
        /// Дата документа основания в формате "DD.MM.YYYY"
        /// </summary>
        [DataMember]
        public string DocumentDate { get; set; }
        /// <summary>
        /// Номер документа основания
        /// </summary>
        [DataMember]
        public string DocumentNumber { get; set; }
        /// <summary>
        /// Значение отраслевого реквизита
        /// </summary>
        [DataMember]
        public string AttributeValue { get; set; }
    }
}
