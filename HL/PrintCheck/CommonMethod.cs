using DAL.Entities;
using DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HL.PrintCheck
{
    public class CommonMethod : Document
    {
        private static dynamic com { get; set; }
        [DataMember]
        public string Password { get; set; }
        public int res { get; set; }

        private string is54FZ;

        public string ReadTableReq(int tableNumber, int rowNumber, int fieldNumber, out bool fieldType)
        {
            int result;
            SetPassword();
            com.TableNumber = tableNumber;
            com.FieldNumber = fieldNumber;
            result = com.GetFieldStruct();
            if (result == 0)
            {
                fieldType = com.FieldType;
            }
            else
            {
                fieldType = false;
                return "error";
            }
            com.TableNumber = tableNumber;
            com.FieldNumber = fieldNumber;
            com.RowNumber = rowNumber;
            result = com.ReadTable();
            if (fieldType)
            {
                return com.ValueOfFieldString;
            }
            else
            {
                return com.ValueOfFieldInteger.ToString();
            }
        }

        public int WriteTableReq(int tableNumber, int rowNumber, int fieldNumber, string value)
        {
            int result;
            bool fieldType;
            SetPassword();
            com.TableNumber = tableNumber;
            com.FieldNumber = fieldNumber;
            result = com.GetFieldStruct();

            if (result == 0)
            {
                fieldType = com.FieldType;
            }
            else
            {
                fieldType = false;
            }
            com.TableNumber = tableNumber;
            com.FieldNumber = fieldNumber;
            com.RowNumber = rowNumber;
            if (fieldType)
            {
                com.ValueOfFieldString = value;
            }
            else
            {
                if ((int.TryParse(value, out int valueInt)))
                {
                    com.ValueOfFieldInteger = value;
                }
                else
                {
                    //ошибка

                    return -1;
                }
            }
            result = com.WriteTable();
            return result;
        }

        public void SetPassword(string password = null)
        {
            int pass = 30;
            if (!string.IsNullOrEmpty(password))
                int.TryParse(password, out pass);
            else
                int.TryParse(Password, out pass);

            com.Password = pass;
        }
        public int OpenCheck(Check check)
        {
            res = SetCashier(check.Cashier);

            // 0 - продажа,
            // 1 - покупка,
            // 2 - возврат продажи,
            // 3 - возврат покупки
            int checkType;
            switch (check.CheckType)
            {
                case CheckTypes.Продажа: checkType = 0; break;
                case CheckTypes.Покупка: checkType = 1; break;
                case CheckTypes.Возврат: checkType = 2; break;
                case CheckTypes.ВозвратПокупки: checkType = 3; break;
                default: checkType = 0; break;
            }
            com.CheckType = checkType;

            SetPassword(check.Password);
            com.TaxValue1 = 0;
            com.TaxValue2 = 0;
            com.TaxValue3 = 0;
            com.TaxValue4 = 0;
            com.TaxValue5 = 0;
            com.TaxValue6 = 0;
            res = com.OpenCheck();

            SendEmail(check);
            return res;
        }
        private int SetCashier(string cashier)
        {
            if (string.IsNullOrEmpty(cashier))
            {
                cashier = "Кассир";
            }
            SetPassword();
            com.TableNumber = 2;
            com.RowNumber = 30;
            com.FieldNumber = 2;
            com.ValueOfFieldString = cashier;
            return com.WriteTable();
        }

        private int SendEmail(Check check)
        {
            if (Is54FZ())
            {
                if (PrintOnlyElectronicChecks)
                {
                    if (string.IsNullOrEmpty(check.ClientContact))
                    {
                        check.ClientContact = PrintOnlyElectronicChecksDefaultContact;
                    }
                }
                if (!string.IsNullOrEmpty(check.ClientContact))
                {
                    SetPassword(check.Password);

                    com.CustomerEmail = check.ClientContact;
                    var result = com.FNSendCustomerEmail();

                    return result;
                }
            }
            return -1;
        }
        private bool Is54FZ()
        {
            lock (com)
            {
                if (!string.IsNullOrEmpty(is54FZ) && (is54FZ != "null"))
                {
                    return is54FZ == "true" ? true : false;
                }
                com.ModelParamNumber = 71;
                res = com.ReadModelParamValue();
                if (res == 0)
                {
                    string value = com.ModelParamValue;
                    if (value.ToLower() == "true")
                    {
                        is54FZ = "true";
                        return true;
                    }
                    else
                    {
                        is54FZ = "false";
                        return false;
                    }
                }

                is54FZ = "null";
                return false;
            }
        }
        //public void SetError(Check c, bool cancel = true)
        //{
        //    int code = com.ResultCode;
        //    var description = GetAdditionalErrorDescription(code);
        //    SetError(c, code, description);
        //    if (cancel)
        //        res = com.CancelCheck();
        //}

        //public string GetAdditionalErrorDescription(int resultCode)
        //{
        //    string descriptionAdditional = com.ResultCodeDescription;
        //    if (resultCode == 0)
        //        return descriptionAdditional;

        //    // Если команда не поддерживается в данном режиме, добавляем в описание ошибки какой сейчас режим.
        //    if (resultCode == 115)
        //    {
        //        res = com.GetShortECRStatus();
        //        descriptionAdditional += $". Режим ККМ = {com.ECRMode}, Описание '{com.ECRModeDescription}'";
        //    }

        //    // неверное значение в поле длины
        //    if (resultCode == 126)
        //    {
        //        descriptionAdditional += $". Установите в веб-интерфейсе Сервера ККМ параметр 'Длина строки наименования товара' для устройства '{DeviceName}'.";
        //    }

        //    // Нет чековой ленты
        //    if (resultCode == 107)
        //    {
        //        res = com.GetShortECRStatus();
        //        descriptionAdditional += $". Подрежим ККМ = {com.ECRAdvancedMode}, Описание '{com.ECRAdvancedModeDescription}'";
        //    }

        //    // Отдельный поток для проверки подрежима, в случае если требуется команда ContinuePrint вызывает ее.
        //    try
        //    {
        //        var threadCheckEcrAdvandedMod = new Thread(RunContinuePrint);
        //        threadCheckEcrAdvandedMod.Start();
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return descriptionAdditional;
        //}
        //public void RunContinuePrint()
        //{
        //    int advancedMod = 0;
        //    try
        //    {
        //        while (true)
        //        {
        //            Thread.Sleep(500);
        //            com.GetShortECRStatus();
        //            advancedMod = com.ECRAdvancedMode;
        //            // Все ок, можно выходить
        //            if (advancedMod == 0)
        //                break;

        //            // Ожидание подрежима, чтобы продолжить печать
        //            if (advancedMod == 3)
        //            {
        //                res = ContinuePrint();
        //                if (res == 0)
        //                {
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}
        //public int ContinuePrint()
        //{
        //    //lock (com)
        //    //{
        //    //    res = SetDevice();
        //    //    if (res != 0)
        //    //    {
        //    //        return res;
        //    //    }
        //    res = com.ContinuePrint();
        //    return res;
        //    //}
        //}
        ///// <summary>
        ///// Установить ошибку в документ
        ///// </summary>
        //protected virtual void SetError(Document doc, int code, string message)
        //{
        //    string deviceTypeName;
        //    switch (DAL.Enum.DeviceType)
        //    {

        //        case DAL.Enum.DeviceType.Shtrih:
        //            deviceTypeName = "Штрих 4.х";
        //            break;

        //        case DAL.Enum.DeviceType.AtolFRv10:
        //            deviceTypeName = "Атол 10.x";
        //            break;

        //        case DAL.Enum.DeviceType.RBSVikiPrint:
        //            deviceTypeName = "РБСВикиПринт";
        //            break;

        //        case DAL.Enum.DeviceType.EmulatorKKM:
        //            deviceTypeName = "ЭмуляторККМ";
        //            break;

        //        case DAL.Enum.DeviceType.NativeViki:
        //            deviceTypeName = "NativeViki";
        //            break;

        //        default:
        //            deviceTypeName = DAL.Enum.DeviceType.ToString();
        //            break;
        //    }
        //    if (code == 0)
        //        doc.SetError(Error.Ошибок_нет);
        //    else
        //    {
        //        doc.SetError(Error.Ответ_кассы, $" {message}, код ошибки драйвера {code}, Драйвер: {deviceTypeName}");
        //        Log.Fatal($"{message}, код ошибки драйвера {code}, Драйвер: {deviceTypeName} Девайс {this.DeviceId} COM {this.DeviceName} ST {Environment.StackTrace.Replace("naimanov", "src")}");
        //    }
        //}
        //private int PrintCheckLines(List<PrintLine> lines)
        //{
        //    if (lines == null) return 0;

        //    if (RedLog)
        //        Log.Information($"_S_{DeviceName}_PrintCheckLines");
        //    foreach (var item in lines)
        //    {
        //        int r = PrintLine(item.Line);
        //        if (r != 0)
        //            return r;
        //    }
        //    return 0;
        //}
    }
}
