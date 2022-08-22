using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.CheckComponents
{
    /// <summary>
    /// Данные поставщика
    /// </summary>
    [Serializable]
    [DataContract]
    public class CheckPurveyorData
    {
        /// <summary>
        /// Телефон поставщика
        /// </summary>
        [DataMember]
        public string PurveyorPhone { get; set; }
        /// <summary>
        /// Наименование поставщика
        /// </summary>
        [DataMember]
        public string PurveyorName { get; set; }
        /// <summary>
        /// ИНН поставщика
        /// </summary>
        [DataMember]
        public string PurveyorVATIN { get; set; }
    }

}
