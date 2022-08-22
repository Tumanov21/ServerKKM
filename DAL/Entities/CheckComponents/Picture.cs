using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.CheckComponents
{
    /// <summary>
    /// Изображение
    /// </summary>
    [DataContract]
    [Serializable]
    public class Picture
    {
        /// <summary>
        /// Bitmap изображение в формате base64
        /// </summary>
        [DataMember]
        public string Base64 { get; set; }
        /// <summary>
        /// Название изображения
        /// </summary>
        [DataMember] public string PictureName { get; set; }
        /// <summary>
        /// Длина
        /// </summary>
        [DataMember]
        public int Width { get; set; }
        /// <summary>
        /// Ширина
        /// </summary>
        [DataMember]
        public int Height { get; set; }
        /// <summary>
        /// Номер первой строки печати изображения
        /// </summary>
        [DataMember]
        public int StartLineNumber { get; set; }
        /// <summary>
        /// Номер последней строки печати изображения
        /// </summary>
        [DataMember]
        public int EndLineNumber { get; set; }
        /// <summary>
        /// 1 left - по левому краю
        /// 2 center - по центру
        /// 3 right - по правому краю
        /// по умолчанию - center
        /// </summary>
        [DataMember]
        public int Alignment { get; set; }

        /// <summary>
        /// Дата загрузки в память ККТ
        /// </summary>
        [DataMember]
        public DateTime? Uploaded { get; set; }
        /// <summary>
        /// Загружен в память ККТ
        /// </summary>
        [DataMember]
        public bool IsUploaded { get; set; }
        /// <summary>
        /// Перезаписать
        /// </summary>
        [DataMember]
        public bool Override { get; set; }
    }
}
