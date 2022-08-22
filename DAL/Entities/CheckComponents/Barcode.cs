using DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.CheckComponents
{
    /// <summary>
    /// Штрихкод
    /// </summary>
    [DataContract]
    [Serializable]
    public class Barcode
    {
        /// <summary>
        /// Тип штрихкода
        /// </summary>
        [DataMember]
        public string BarcodeType { get; set; }

        /// <summary>
        /// Значение штрихкода
        /// </summary>
        [DataMember]
        public string BarcodeText { get; set; }

        /// <summary>
        /// Проверка штрихкода
        /// </summary>
        /// <param name="barcode">
        /// Штрихкод
        /// </param>
        /// <param name="type">
        /// Тип
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsValid(Barcode barcode, out BarcodeTypes type)
        {
            type = BarcodeTypes.CODE128;
            if (barcode == null)
                return false;
            if (string.IsNullOrWhiteSpace(barcode.BarcodeType))
                return false;
            if (string.IsNullOrWhiteSpace(barcode.BarcodeText))
                return false;

            return false;
        }
    }
}
