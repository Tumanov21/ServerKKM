using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enum
{
    /// <summary>
    /// Тип устройства
    /// </summary>
    [DataContract]
    public enum DeviceType
    {
        [EnumMember]
        Shtrih = 1,

        [EnumMember]
        AtolFRv10 = 3,

        [EnumMember]
        RBSVikiPrint = 4,

        [EnumMember]
        EmulatorKKM = 5,

        [EnumMember]
        WindowsPrinter = 6,

        [EnumMember]
        NativeViki = 7,
    }
}
