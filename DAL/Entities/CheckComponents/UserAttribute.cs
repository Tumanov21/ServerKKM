using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.CheckComponents
{
    [Serializable]
    [DataContract]
    public class UserAttribute
    {
        /// <summary>
        /// 	Имя реквизита
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Значение реквизита
        /// </summary>
        [DataMember]
        public string Value { get; set; }
    }
}
