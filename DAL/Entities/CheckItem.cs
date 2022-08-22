using DAL.Entities.CheckComponents;
using DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    /// <summary>
    /// Элемент чека / позиция в чеке
    /// </summary>
    [Serializable]
    [DataContract]
    public class CheckItem
    {
        /// <summary>
        /// Наименование позиции
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        [DataMember]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Цена позиции
        /// </summary>
        /// <remarks>
        /// Значение цены переданное клиентом теперь не важно август 2018
        /// цена расчитвается  в методе SetPriceWithDiscount
        /// </remarks>
        [DataMember]
        public decimal Price { get; set; }

        /// <summary>
        /// Сумма с учетом скидки
        /// Запрещено изменять на сервере.
        /// </summary>
        /// <remarks>
        /// Передается клиентской частью для автоматического вычисления цены
        /// Price=Summ/Count в методе SetPriceWithDiscount
        /// </remarks>
        [DataMember]
        public decimal Summ { get; set; }

        /// <summary>
        /// Дополнительная информация
        /// </summary>
        [DataMember]
        public string AdditionalAttribute;

        [DataMember]
        [Obsolete("Скидка вычисляется на сервере и учитывается в цене, затем записывается в DiscountInfoValue, и может быть распечатана как справочная информация, от клиента эти данные не нужны. ")]
        public decimal DiscountValue;

        /// <summary>
        /// Больше 0 - Скидка
        /// Меньше 0 - Надбавка
        /// </summary>
        [DataMember]
        public decimal DiscountInfoValue;

        /// <summary>
        /// Департамент/отдел
        /// </summary>
        [DataMember]
        public int? Department { get; set; }
        /// <summary>
        /// Возврат
        /// </summary>
        [DataMember]
        public bool isreturn;

        /// <summary>
        /// Фискальный
        /// </summary>
        [DataMember]
#pragma warning disable IDE1006 // Стили именования
        public bool isFiscal { get; set; }

#pragma warning restore IDE1006 // Стили именования

        /// <summary>
        /// Ставка НДС может быть 0,10,18,20,110,118,120, -1 = БЕЗ НДС
        /// </summary>
        [DataMember]
        public int TaxValue { get; set; }

        /// <summary>
        /// Признак способа расчёта
        /// </summary>
        [DataMember]
        public PaymentModes PaymentMode { get; set; }

        /// <summary>
        /// Признак предмета расчёта
        /// </summary>
        [DataMember]
        public ItemTypes ItemType { get; set; }

        /// <summary>
        /// СуммаНДС
        /// </summary>
        [DataMember]
        public decimal TaxSum { get; set; }

        /// <summary>
        /// Штрихкод
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Barcode Barcode;

        /// <summary>
        /// Изображение
        /// </summary>
        [DataMember]
        public Picture Picture;

        /// <summary>
        /// Получить тип элемента
        /// </summary>
        /// <returns></returns>
        //public TypeItem GetTypeItem()
        //{
        //    if (isFiscal) return TypeItem.Fiscal;
        //    if (Barcode != null) return TypeItem.Barcode;
        //    if (!string.IsNullOrWhiteSpace(Picture?.PictureName))
        //    {
        //        return TypeItem.Picture;
        //    }
        //    return TypeItem.TextString;
        //}
        /// <summary>
        /// Запись в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Применяется при печати не фискальных чеков
            if ((Price == 0) && (Quantity == 0))
                return Name;

            string str = Name + " " + Price + "*" + Quantity;
            if (DiscountInfoValue != 0)
                str += "-" + DiscountInfoValue;
            str += "=" + Summ;

            return str;
        }

        /// <remarks>
        /// Реквизиты «адрес оператора перевода» (тег 1005), «ИНН оператора перевода» (тег 1016),
        /// «наименование оператора перевода» (тег 1026), «операция платежного агента» (тег 1044),
        /// «признак агента» (тег 1057),«телефон платежного агента» (тег 1073), «телефон оператора по приему платежей» (тег 1074),
        /// «телефон оператора перевода» (тег 1075), «телефон поставщика» (тег 1171) включаются в состав кассового чека (БСО)
        /// в случае,если данные этих реквизитов идентичны для каждого из реквизитов «предмет расчета» (тег 1059),
        /// входящего в состав кассового чека (БСО), который содержит сведения о расчетах пользователя, являющегося платежным агентом (субагентом),
        /// банковским платежным агентом (субагентом), комиссионером, поверенным или иным агентом, в ином случае указанные реквизиты
        /// должны включаться в состав реквизита «данные агента» (тег 1223) в реквизите «предмет расчета» (тег 1059).
        /// Реквизиты «признак агента» (тег1057), «телефон платежного агента» (тег1073),
        /// «телефон оператора по приему платежей» (тег1074) и «телефон поставщика» (тег1171)
        /// включаются в состав кассового чека(БСО), который содержит сведения о расчетах пользователя,
        /// являющегося платежным агентом или платежным субагентом. Реквизиты «адрес оператора перевода» (тег1005),
        /// «ИНН оператора перевода» (тег1016), «наименование оператора перевода» (тег1026),
        /// «операция платежного агента» (тег1044), «признак агента» (тег1057), «телефон платежного агента» (тег1073),
        /// «телефон оператора перевода» (тег1075) и «телефон поставщика» (тег1171) включаются в состав кассового чека(БСО),
        /// который содержит сведения о расчетах пользователя, являющегося банковским платежным агентом или банковским платежным субагентом.
        /// Реквизиты «признак агента» (тег1057) и «телефон поставщика» (тег1171) включаются в состав кассового чека(БСО),
        /// который содержит сведения о расчетах пользователя, являющегося комиссионером, поверенным или иным агентом.
        /// Реквизты включсенные в  AgentDataItem обязательны в ФФД 1.1 и рекомендованы в ФФД 1.05
        /// </remarks>
        [DataMember]
        public CheckAgentData AgentDataItem;

        /// <summary>
        /// Данные поставщика
        /// </summary>
        [DataMember]
        public CheckPurveyorData PurveyorDataItem;

        /// <summary>
        /// Признак агента по предмету расчета
        /// </summary>
        [DataMember]
        public int? SignSubjectCalculationAgent { get; set; }

        [DataMember]
        private PrintLine After { get; set; }

        [DataMember]
        private PrintLine Before { get; set; }
        /// <summary>
        /// Цифровой код страны происхождения товара в соответствии с Общероссийским классификатором стран мира
        /// </summary>
        [DataMember]
        public string CountryOfOrigin;
        /// <summary>
        /// Регистрационный номер таможенной декларации
        /// </summary>
        [DataMember]
        public string CustomsDeclaration;

        /// <summary>
        /// Сумма акциза с учетом копеек, включенная в стоимость предмета расчета
        /// </summary>
        [DataMember]
        public decimal? ExciseAmount { get; set; } = null;

        // TODO MeasurementUnit? ЕдиницаИзмеренияПредметаРасчета Атрибуты с ФФД 1.1
        /// <summary>
        /// Единица измерения предмета расчета
        /// </summary>
        [DataMember]
        public string MeasurementUnit;

        /// <summary>
        /// Код товарной номенклатуры
        /// </summary>
        //[DataMember(EmitDefaultValue = false)]
        //public CommodityNomenclatureCode GoodCodeData { get; set; }

        /// <summary>
        /// Код маркировки
        /// </summary>
        [DataMember]
        public string MarkingCode;

        /// <summary>
        /// Мера количества предмета расчета.
        /// Значение из таблицы 114 (ФФД)
        /// </summary>
        [DataMember]
        public int? MeasureOfQuantity { get; set; }
        /// <summary>
        /// Дробное количество маркированного товара
        /// </summary>
        [DataMember]
        public int? FractionalQuantityNumerator { get; set; }
        /// <summary>
        /// Дробное количество маркированного товара
        /// </summary>
        [DataMember]
        public int? FractionalQuantityDenominator { get; set; }
        /// <summary>
        /// Отраслевой реквизит предмета расчета
        /// </summary>
        [DataMember]
        public IndustryAttribute IndustryAttribute;
        /// <summary>
        /// Данные проверки КМ
        /// </summary>
        //[DataMember]
        //public A10ImcParams ImcParams { get; set; }
        /// <summary>
        /// Код товара
        /// </summary>
        [DataMember] public string ProductCode;
    }
}

