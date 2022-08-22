using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.CheckComponents
{
    /// <summary>
    /// Строка печати
    /// </summary>
    [Serializable]
    [DataContract]
    public class PrintLine
    {
        //public PrintLine()
        //{
        //}

        //public PrintLine(string Text, Alignment alignment, PrintFont Font, bool Wrap)
        //{
        //    Line = Text;
        //    Alignment = alignment;
        //    this.Font = Font;
        //    this.Wrap = Wrap;
        //}
        ///// <summary>
        ///// Линия
        ///// </summary>
        //[DataMember]
        //public string Line { get; set; }
        ///// <summary>
        ///// Выравнивание
        ///// </summary>
        //[DataMember]
        //public Alignment Alignment { get; set; }

        ///// <summary>
        ///// Шрифт
        ///// </summary>
        //[DataMember]
        //public PrintFont Font { get; set; }

        ///// <summary>
        ///// Обрезка
        ///// </summary>
        //[DataMember]
        //public bool Wrap { get; set; }

        ///// <summary>
        ///// Штрихкод
        ///// </summary>
        //[DataMember(EmitDefaultValue = false)]
        //public Barcode Barcode { get; set; }

        ///// <summary>
        ///// Получить тип строки
        ///// </summary>
        ///// <returns></returns>
        //public TypeItem GetTypeItem()
        //{
        //    if (Barcode != null) return TypeItem.Barcode;
        //    return TypeItem.TextString;
        //}
    }
}
