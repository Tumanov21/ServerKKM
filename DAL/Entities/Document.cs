using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Document
    {
        /// <summary>
        /// Идентификатор документа
        /// </summary>
        [DataMember]
        public Guid DockId { get; set; }

        /// <summary>
        /// Идентификатор терминала
        /// </summary>
        [DataMember]
        public string TerminalId { set; get; }

        /// <summary>
        /// Идентификатор устройства для печати
        /// </summary>
        [DataMember]
        public Guid DeviceId { get; set; }

        ///// <summary>
        ///// Head text
        ///// </summary>
        //[DataMember]
        //public List<PrintLine> Before { get; set; }

        ///// <summary>
        ///// Bottom Text
        ///// </summary>
        //[DataMember]
        //public List<PrintLine> After { get; set; }

        /// <summary>
        /// Номер сессии
        /// </summary>
        [DataMember]
        public int SessionNumber { get; set; }

        /// <summary>
        /// Дата создания документа
        /// </summary>
        [DataMember]
        public DateTime Date { get; set; }

        /// <summary>
        /// Номер фискального документа
        /// </summary>
        [DataMember]
        public int DocNumber { get; set; }

        /// <summary>
        /// Номер фискального документа
        /// </summary>
        [DataMember]
        public int DocNumberInShift { get; set; }

        /// <summary>
        /// Фискальный признак документа
        /// </summary>
        [DataMember]
        public string FiscalSign { get; set; }

        /// <summary>
        /// Фискальный накопитель
        /// </summary>
        [DataMember]
        public string Fn { get; set; }

        //[DataMember]
        //public DocTypes DocType { get; set; }

        /// <summary>
        /// Результат
        /// </summary>
        [DataMember]
        public int ResultCode { get; set; }

        [DataMember]
        public string ResultDescription { get; set; }

        /// <summary>
        /// Имя кассира
        /// </summary>
        [DataMember]
        public string Cashier { get; set; }

        //ФФД1.0.5

        /// <summary>
        /// ИНН кассира
        /// </summary>
        [DataMember]
        public string CashierVATIN { get; set; }

        /// <summary>
        /// Версия клиента
        /// </summary>
        /// <value>
        /// 1.0.0.0
        /// </value>
        [DataMember]
        public string Ver { get; set; }

        /// <summary>
        /// Данные для печати QR кода
        /// </summary>
        //[DataMember]
        //public QRData QRData { get; set; }

        ///// <summary>
        ///// Заголовок документа
        ///// </summary>
        //[DataMember]
        //public DocumentHeader DocumentHeader { get; set; }

        ///// <summary>
        ///// Нет ссылок - на удаление
        ///// </summary>
        //public string Rnm { get; set; }
        ///// <summary>
        ///// Выходные параметры для документов, возвращаются в 1с
        ///// </summary>
        //[DataMember]
        //public OutputParameters OutputParameters { get; set; }

        /// <summary>
        /// Наименование принтера
        /// </summary>
        [DataMember]
        public string PrinterName { get; set; }
        /// <summary>
        /// Адрес проведения расчетов
        /// </summary>
        [DataMember]
        public string SaleAddress { get; set; }
        /// <summary>
        /// Место проведения расчетов
        /// </summary>
        [DataMember]
        public string SaleLocation { get; set; }

        [DataMember]
        public int SizeQueue { get; set; }
        [DataMember]
        public int PositionPoolQueue { get; set; }
    }
}
