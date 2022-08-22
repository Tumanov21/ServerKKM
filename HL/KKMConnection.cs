using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HL
{
    public class KKMConnection
    {
        [IgnoreDataMember]
        [XmlIgnore]
        private static dynamic com { get; set; }
        public string id { get; set; }
        public string pool { get; set; } //на Pool
        public int priority { get; set; }//очередность печати  
        public int connectionType { get; set; } //0 - порт 1-сеть

        public int timeout { get; set; } //таймаут, количество миллисекунд на ожидаение ответа от ККМ

        //Для COM-порта
        public int comPort { get; set; } //1..255


        /*      Значение параметра BaudRate Скорость обмена  
                0 2400
                1 4800
                2 9600
                3 19200
                4 38400
                5 57600
                6 115200 */
        public int baudRate { get; set; }//0..6

        //Для TCP
        public string address { get; set; }
        public int port { get; set; }

        [IgnoreDataMember]
        [XmlIgnore]
        public string resultDescription { get; set; }

        [IgnoreDataMember]
        [XmlIgnore]
        public int resultCode { get; set; }

        public int LoadDriver()
        {
            try
            {
                com = Print.GetShtrihInstance();
#if DEBUG
                com.LogOn = true; //включаем режим записи логов драйвера Штрих
#endif
                resultCode = 0;
            }
            catch (Exception ex)
            {
                resultCode = -1; //не загрузился драйвер
                resultDescription = ex.Message;
            }
            return resultCode;
        }


        //public int PrintCheck(Check check)
        //{
        //    try
        //    {
        //        foreach (var item in check.CheckItems)
        //        {
        //            com.CheckType = check.CheckType;
        //            com.Price = item.Price;
        //            com.Quantity = item.Quantity;
        //            com.Summ1Enabled = true; // Указываем, что сами рассчитываем цену
        //                                     //Summ1Enabled Логич. - RW Использовать сумму операции*

        //            com.Summ1 = item.Summ; // Сумма позиции с учетом скидок
        //                                   //Summ1 Денеж. 0…9999999999 RW Сумма операции 324


        //            com.TaxValueEnabled = false; // Налог в строке не считаем
        //                                         //TaxValue Денеж. 0…9999999999 RW Сумма налога 284
        //                                         //TaxValueEnabled Логич. - RW Использовать сумму налога** 284
        //                                         //Tax1 Целое 0..6 RW Налоговая ставка 336

        //            com.Tax1 = check.GetNumTaxCode(item.TaxValue); // НДС 18%


        //            com.Department = item.Department; // Номер отдела
        //            com.PaymentTypeSign = 4; // Признак способа расчета (Полный расчет)
        //                                     // Необходим для ФФД 1.05
        //            com.PaymentItemSign = 1; // Признак предмета расчета (Товар)
        //                                     // Необходим для ФФД 1.05
        //            com.StringForPrinting = item.Name; // Наименование товара

        //            resultCode = com.FNOperation();
        //            if (resultCode != 0)
        //                resultDescription = com.ResultCodeDescription;// Пробиваем позицию
        //        }
        //        com.Summ1 = check.CashPayment;
        //        com.Summ2 = check.ElectronicPayment;
        //        com.Summ3 = 0;           // Остальные типы оплаты нулевые,но их необходимо заполнить
        //        com.Summ4 = 0;
        //        com.Summ5 = 0;
        //        com.Summ6 = 0;
        //        com.Summ7 = 0;
        //        com.Summ8 = 0;
        //        com.Summ9 = 0;
        //        com.Summ10 = 0;
        //        com.Summ11 = 0;
        //        com.Summ12 = 0;
        //        com.Summ13 = 0;
        //        com.Summ14 = check.CreditPayment ;     //зачет аванса
        //        com.Summ15 = check.AdvancePayment ;     //кредит
        //        com.Summ16 = check.CashProvisionPayment ;

        //        com.RoundingSumm = 0; // Сумма округления
        //        com.TaxValue1 = 0; // Налоги мы не считаем
        //        com.TaxValue2 = 0;
        //        com.TaxValue3 = 0;
        //        com.TaxValue4 = 0;
        //        com.TaxValue5 = 0;
        //        com.TaxValue6 = 0;
        //        com.TaxType = 1; // Основная система налогообложения
        //        com.StringForPrinting = "";

        //        resultCode = com.FNCloseCheckEx();
        //        if (resultCode != 0)// Пробиваем позицию
        //            resultDescription = com.ResultCodeDescription;
        //        return resultCode;

        //    }
        //    catch (Exception e)
        //    {
        //        com.Disconnect();
        //        resultCode = -1;//произошло исключение
        //        resultDescription = e.Message;
        //        return resultCode;
        //    }
        //    check.CheckNumber = com.DocumentNumber;
        //    check.fiscalSign = com.FiscalSign;
        //    check.FiscalSignAsString = com.FiscalSignAsString;

        //    return resultCode;
        //}

        public int PrintCheck(Check check)
        {
            try
            {
                if (check.CheckType == DAL.Enum.CheckTypes.Продажа)
                    com.CheckType = 0;
                if (check.CheckType == DAL.Enum.CheckTypes.Возврат)
                    com.CheckType = 2;
                if (check.CheckType == DAL.Enum.CheckTypes.ВозвратПокупки)
                    com.CheckType = 3;

                if (check.CheckType == DAL.Enum.CheckTypes.Покупка)
                    com.CheckType = 1;

                com.Password = 30;
                resultCode = com.FNCloseCheckEx();
                resultDescription = com.ResultCodeDescription;
                
                resultCode = com.OpenCheck();
                if (resultCode !=0 )
                {
                    resultCode = com.FNCloseCheckEx();
                    resultCode = com.OpenCheck();
                }
                if (resultCode != 0)
                {
                    resultDescription = com.ResultCodeDescription;
                    return resultCode;
                }

                foreach (var item in check.CheckItems)
                {
                    com.CheckType = check.CheckType;
                    com.Price = item.Price;
                    com.Quantity = item.Quantity;
                    com.Summ1Enabled = true; // Указываем, что сами рассчитываем цену
                                             //Summ1Enabled Логич. - RW Использовать сумму операции*

                    com.Summ1 = item.Summ; // Сумма позиции с учетом скидок
                                           //Summ1 Денеж. 0…9999999999 RW Сумма операции 324


                    com.TaxValueEnabled = false; // Налог в строке не считаем
                                                 //TaxValue Денеж. 0…9999999999 RW Сумма налога 284
                                                 //TaxValueEnabled Логич. - RW Использовать сумму налога** 284
                                                 //Tax1 Целое 0..6 RW Налоговая ставка 336

                    com.Tax1 = check.GetNumTaxCode(item.TaxValue); // НДС 18%


                    com.Department = item.Department; // Номер отдела
                    com.PaymentTypeSign = 4; // Признак способа расчета (Полный расчет)
                                             // Необходим для ФФД 1.05
                    com.PaymentItemSign = 1; // Признак предмета расчета (Товар)
                                             // Необходим для ФФД 1.05
                    com.StringForPrinting = item.Name; // Наименование товара

                    resultCode = com.FNOperation();
                    if (resultCode != 0)
                        resultDescription = com.ResultCodeDescription;// Пробиваем позицию
                }
                com.Summ1 = check.CashPayment;
                com.Summ2 = check.ElectronicPayment;
                com.Summ3 = 0;           // Остальные типы оплаты нулевые,но их необходимо заполнить
                com.Summ4 = 0;
                com.Summ5 = 0;
                com.Summ6 = 0;
                com.Summ7 = 0;
                com.Summ8 = 0;
                com.Summ9 = 0;
                com.Summ10 = 0;
                com.Summ11 = 0;
                com.Summ12 = 0;
                com.Summ13 = 0;
                com.Summ14 = check.CreditPayment;     //зачет аванса
                com.Summ15 = check.AdvancePayment;     //кредит
                com.Summ16 = check.CashProvisionPayment;

                com.RoundingSumm = 0; // Сумма округления
                com.TaxValue1 = 0; // Налоги мы не считаем
                com.TaxValue2 = 0;
                com.TaxValue3 = 0;
                com.TaxValue4 = 0;
                com.TaxValue5 = 0;
                com.TaxValue6 = 0;
                com.TaxType = 1; // Основная система налогообложения
                com.StringForPrinting = "";

                resultCode = com.FNCloseCheckEx();
                if (resultCode != 0)// Пробиваем позицию
                    resultDescription = com.ResultCodeDescription;
                return resultCode;

            }
            catch (Exception e)
            {
                com.Disconnect();
                resultCode = -1;//произошло исключение
                resultDescription = e.Message;
                return resultCode;
            }
            check.CheckNumber = com.DocumentNumber;
            check.fiscalSign = com.FiscalSign;
            check.FiscalSignAsString = com.FiscalSignAsString;

            return resultCode;
        }
        public string Error()
        {
            return "Error";
        }

        public int Connect()
        {
            // Метод выполняет следующие действия:
            // 1. Занимает COM порт с номером ComNumber;
            // 2. Устанавливает скорость порта BaudRate;
            // 3. Устанавливает таймаут приёма байта порта Timeout;
            // 4. Запрашивает состояние устройства путём выполнения метода GetECRStatus.
            // 5. Запрашивает параметры устройства путём выполнения метода GetDeviceMetrics.

            com.ComNumber = comPort;
            com.BaudRate = baudRate;
            com.Timeout = timeout;
            com.ProtocolType = 0;//0-стандартный 1- ККМ 2.0
            if (connectionType == 0)
            {
                com.ConnectionType = 0; //локальное
            }
            else
            {
                com.ConnectionType = 6; //через tcp-сокет
            }

            resultCode = com.Connect();
            resultDescription = com.ResultCodeDescription;
            return resultCode;
        }
    }
}
