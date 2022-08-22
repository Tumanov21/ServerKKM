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
    [Serializable]
    [DataContract]
    public class Check
    {
        /// <summary>
        /// Подтвержден в ФН
        /// </summary>
        [DataMember]
        public bool TrustedInFn { get; set; }
        //public Check()
        //    : base(DocTypes.Чек)
        //{
        //    TaxType = TaxVariants.None;
        //    //QRData = new QRData();
        //}

        /// <summary>
        /// Номер чека в смене
        /// </summary>
        [DataMember]
        public int CheckNumber { get; set; }

        /// <summary>
        /// Позиции чека
        /// </summary>

        [DataMember] public List<CheckItem> CheckItems { get; set; }

        /// <summary>
        /// Сдача
        /// </summary>
        [DataMember] public decimal Change { get; set; }

        //[DataMember] public string UserAttribute { get; set; }

        /// <summary>
        /// Оплата наличными
        /// </summary>
        [DataMember]
        public int CashPayment { get; set; }

        /// <summary>
        /// СуммаЭлектронными
        /// </summary>
        [DataMember]
        //public Payment ElectronicPayment { get; set; }
        public int ElectronicPayment { get; set; }

        /// <summary>
        /// СуммаПостоплатой
        /// </summary>
        [DataMember]
        public int CreditPayment { get; set; }

        /// <summary>
        /// СуммаПредоплатой
        /// </summary>
        [DataMember]
        public int AdvancePayment { get; set; }

        /// <summary>
        /// СуммаПредоставлением
        /// </summary>
        [DataMember]
        public int CashProvisionPayment { get; set; }


        /// <summary>
        /// Сумма чека
        /// </summary>
        [DataMember]
        public decimal Summ;

        /// <summary>
        /// Внесённая сумма налом
        /// </summary>
        [DataMember]
        [Obsolete()]
        public double InjectSumm { get; set; }

        /// <summary>
        /// Оплачено ранее
        /// </summary>
        [DataMember] public double Paid;

        /// <summary>
        /// Департамент
        /// </summary>
        [DataMember] public int? Department;

        /// <summary>
        /// Бонусы
        /// </summary>
        [DataMember][Obsolete()] public double Bonus;

        /// <summary>
        /// Бонусов осталось
        /// </summary>
        [DataMember][Obsolete()] public double BonusLeft;

        /// <summary>
        /// Значение скидки
        /// </summary>
        [DataMember]
        [Obsolete("Скидку на чек, по закону 54-ФЗ уже запрещено применять")]
        public decimal DiscountValue;

        [DataMember] public int TypeClose;

        /// <summary>
        /// Пароль кассира
        /// </summary>
        [DataMember]
        public string Password { get; set; }

        /// <summary>
        /// Тип чека
        /// </summary>
        [DataMember]
        public CheckTypes CheckType { get; set; }

        /// <summary>
        /// Режим чека
        /// Признак печати чека на чековой ленте:
        /// 0 – электронный чек (не печатается на чековой ленте);
        /// 1 – чек печатается на чековой ленте.
        /// Значение по умолчанию = 1.
        ///
        /// Также это значение применяется для чеков коррекции
        ///  Тип коррекции:
        /// 	0 - самостоятельная операция
        /// 	1 - операция по предписанию
        /// </summary>
        [DataMember]
        public int CheckMode { get; set; }

        /// <summary>
        /// Номер телефона клиента или электронная почта
        /// </summary>
        [DataMember]
        public string ClientContact;

        /// <summary>
        /// Фискальный
        /// </summary>
        [DataMember]
        public bool IsFiscal { get; set; }

        /// <summary>
        /// Код налогообложения
        /// </summary>
        [DataMember]
        public TaxVariants TaxType { get; set; }

        /// <summary>
        /// Отправитель Email
        /// </summary>
        [DataMember]
        public string SenderEmail;

        ///// <summary>
        ///// Адрес проведения расчетов
        ///// </summary>
        //[DataMember]
        //public string AddressSettle { get; set; }

        /// <summary>
        /// Cведения о покупателе (клиенте)
        /// </summary>

        /// <summary>
        /// Email покупателя
        /// </summary>
        [DataMember]
        public string CustomerEmail;

        ///// <summary>
        ///// Место проведения расчетов
        ///// </summary>
        //[DataMember]
        //public string PlaceSettle { get; set; }

        /// <summary>
        /// Признак агента
        /// </summary>
        /// <remarks>
        /// Cвойство nullable. При значении null не пердается дарйвером в ККМ, при значении 0 - Банковский платежный агент.
        /// </remarks>
        [DataMember]
        public int? AgentSign { get; set; }

        /// <summary>
        /// Дополнительный реквизит чека
        /// </summary>
        [DataMember]
        public string AdditionalAttribute;
        /// <summary>
        /// Дополнительный реквизит пользователя
        /// </summary>
        [DataMember] public UserAttribute UserAttribute;
        /// <summary>
        /// Операционный реквизит чека
        /// </summary>
        [DataMember] public OperationalAttribute OperationalAttribute;
        /// <summary>
        /// Отраслевой реквизит чека
        /// </summary>
        [DataMember] public IndustryAttribute IndustryAttribute;

        /// <summary>
        /// Дополнительный реквизит чека
        /// </summary>
        [DataMember]
        public CheckAgentData AgentData;

        /// <summary>
        /// Дополнительный реквизит чека
        /// </summary>
        [DataMember]
        public CheckPurveyorData PurveyorData;
        /// <summary>
        /// Информация о покупателе
        /// </summary>
        [DataMember]
        public string CustomerInfo;

        /// <summary>
        /// ИНН покупателя
        /// </summary>
        [DataMember]
        public string CustomerINN;

        //[DataMember]
        //public int Position { get; set; }

        //[DataMember]
        //public int SizeQueue { get; set; }

        //Ставка НДС может быть 0,10,18,20,110,118,120, -1 = БЕЗ НДС
        public int GetNumTaxCode(int taxValue)
        {
            if (taxValue == 0)
            {
                return 0;
            }
            else if (taxValue == 20)
            {
                return 1;
            } 
            else if (taxValue == 18)
            {
                return 1;
            }
            else if (taxValue == 10)
            {
                return 2;
            }
            else if (taxValue == 0)
            {
                return 3;
            }
            else if (taxValue == 118)
            {
                return 5;
            }
            else if (taxValue == 120)
            {
                return 5;
            }
            else if(taxValue == 110)
            {
                return 6;
            }
            else
            {
                throw new Exception("Передана некорректная ставка НДС");
            }
        }

        [DataMember]
        public string FiscalSignAsString;
        [DataMember]
        public string Cashier { get; set; }
        [DataMember]
        public int fiscalSign { get; set; }
    }
}
