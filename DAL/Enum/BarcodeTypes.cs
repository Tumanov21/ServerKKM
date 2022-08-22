using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enum
{
    /// <summary>
    /// Тип штрихкода
    /// </summary>
    [DataContract]
    public enum BarcodeTypes
    {
        [EnumMember]
        UPCA = 0,

        [EnumMember]
        CODE39 = 1,

        [EnumMember]
        EAN13 = 2,

        [EnumMember]
        EAN8 = 3,

        [EnumMember]
        UPCE = 4,

        [EnumMember]
        ITF = 5,

        [EnumMember]
        CODEBAR = 6,

        [EnumMember]
        CODE93 = 7,

        [EnumMember]
        CODE128 = 8,

        [EnumMember]
        PDF417 = 10,

        [EnumMember]
        CODE32 = 20,

        [EnumMember]
        EAN128CCAB = 82,

        [EnumMember]
        EAN128CCC = 83,

        [EnumMember]
        QR = 84
    }
}
