using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Device
    {
        [DataMember]
        public int MyProperty { get; set; }

        [DataMember]
        public string DeviceName { get; set; }

        /// <summary>
        /// Запущено?
        /// </summary>
        [Obsolete("Не рекомендуется использование этого свойства, потому, что оно не определяется пользователем явно")]
        [DataMember]
        public bool Active { get; set; }

        /// <summary>
        /// Скорость последовательного порта
        /// </summary>
        [DataMember]
        public int BaudRate { get; set; }

        [DataMember]
        public int PortNumber { get; set; }

        [DataMember]
        public string IPaddress { get; set; }

        [DataMember]
        public int TCPport { get; set; }

        //[DataMember]
        //public MethodConnection MethodConnection { get; set; }

        ///// <summary>
        ///// Количество символов в строке нормальным шрифтом
        ///// </summary>

        //[DataMember]
        //[Obsolete]
        //public PrintFont Font { get; set; }
    }
}
