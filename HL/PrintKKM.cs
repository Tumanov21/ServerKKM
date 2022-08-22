using DAL.Entities;
using HL.PrintCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HL
{
    public class PrintKKM
    {
        private readonly CommonMethod _method;
        private readonly FiscalRegistar _fiscal;
        public int res { get; set; }

        [IgnoreDataMember]
        [XmlIgnore]
        private static dynamic com { get; set; }

        public PrintKKM(CommonMethod method, FiscalRegistar fiscal)
        {
            _method = method;
            _fiscal = fiscal;
        }
        //public void PrintCheck(Check check)
        //{
        //    var value1742 = _method.ReadTableReq(17, 1, 7, out var fieldType);
        //    if (_fiscal.PrintOnlyElectronicChecks || check.CheckMode == 0)
        //    {
        //        if (value1742.ToString().ToLower() == "0")
        //        {
        //            _method.WriteTableReq(17, 1, 7, "2");
        //        }

        //        if (string.IsNullOrWhiteSpace(check.ClientContact))
        //        {
        //            check.ClientContact = _fiscal.PrintOnlyElectronicChecksDefaultContact;
        //        }
        //    }
        //    else
        //    {
        //        if (value1742.ToString().ToLower() == "2")
        //        {
        //            _method.WriteTableReq(17, 1, 7, "0");
        //        }
        //    }
        //    res = _method.OpenCheck(check);

        //    if (res == 115)
        //    {
        //        _method.SetPassword();
        //        res = com.SysAdminCancelCheck();
        //        if (res == 0)
        //        {
        //            res = _method.OpenCheck(check);
        //        }
        //    }
        //    if (res != 0)
        //    {
        //        if (res == 80)
        //        {
        //            while (_method.OpenCheck(check) == 80)
        //            {
        //                Thread.Sleep(100);
        //            }
        //        }
        //        else
        //        {
        //            _method.SetError(check);
        //            return check;
        //        }
        //    }
        //    res = PrintCheckLines(check.Before);
        //    if (res != 0)
        //    {
        //        SetError(check);
        //        Log.Information("printchecklines");
        //        return check;
        //    }
        //    Log.Information("действие: установка данных агента и покупателя");
        //    if (Is54FZ())
        //    {
        //        res = SetPrintAgentData(check);

        //        if (_ffd >= 120)
        //        {
        //            check.CustomerDetail ??= new CustomerDetail();

        //            if (string.IsNullOrWhiteSpace(check.CustomerDetail.INN) && !string.IsNullOrWhiteSpace(check.CustomerINN))
        //            {
        //                check.CustomerDetail.INN = check.CustomerINN;
        //            }

        //            if (string.IsNullOrWhiteSpace(check.CustomerDetail.Info) && !string.IsNullOrWhiteSpace(check.CustomerInfo))
        //            {
        //                check.CustomerDetail.Info = check.CustomerInfo;
        //            }
        //        }
        //        else
        //        {
        //            if (!string.IsNullOrEmpty(check.CustomerInfo) && !string.IsNullOrEmpty(check.CustomerINN))
        //            {
        //                res = SendTag(1227, check.CustomerInfo);
        //                Log.Information($"Передача тега 1227 INFO {check.CustomerInfo} : {res}");
        //                res = SendTag(1228, check.CustomerINN);
        //                Log.Information($"Передача тега 1228 INN {check.CustomerINN} : {res}");
        //            }
        //        }
        //    }

        //    Log.Information("действие: установка 'Сведения об операции' и 'Отраслевой реквизит'");
        //    res = WriteFfd120Attributes(check.OperationalAttribute, check.IndustryAttribute, check.CustomerDetail);
        //    if (res != 0)
        //    {
        //        SetError(check, "");
        //        Log.Information("WriteFfd120Attributes");
        //        return check;
        //    }

        //    if (res != 0)
        //    {
        //        SetError(check);
        //        Log.Information("printchecklines");
        //        return check;
        //    }
        //    // регистрация позиций в чеке
        //    Log.Information("действие: регистрация позиций");
        //    if (check.CheckItems != null)
        //    {
        //        foreach (CheckItem item in check.CheckItems)
        //        {
        //            SetPassword(check.Password);
        //            // регистрация позиции
        //            res = RegistrItem(item, check.CheckType);
        //            //проверка результата добавления позиции
        //            if (res != 0)
        //            {
        //                SetError(check);
        //                Log.Information("addfiscal");
        //                return check;
        //            }
        //        }

        //        check.ItemsSumm = CalculateCheckItemsSumm(check.CheckItems);
        //    }
        //    Log.Information("действие: печать линий после");
        //    res = PrintCheckLines(check.After);

        //    // проверка результата
        //    if (res != 0)
        //    {
        //        Log.Information("PrintCheckLines + " + res);
        //        SetError(check);
        //        return check;
        //    }
        //    Log.Information("действие: закрытие чека");
        //    res = CloseCheck(check);

        //    if (res != 0)
        //    {
        //        SetError(check, true);
        //        Log.Information("closecheck");
        //        return check;
        //    }

        //    if (Is54FZ())
        //    {
        //        Log.Information("действие: установка фискальных данных");
        //        SetFiscalInfo(check);
        //    }
        //    else
        //    {
        //        SetPassword(Password);
        //        com.GetECRStatus();
        //        check.DocNumber = com.OpenDocumentNumber + 1;
        //    }

        //    check.Summ = check.ItemsSumm;

        //    check.QRData.Amount = check.Summ;
        //    check.QRData.N = (int)check.CheckType;

        //    res = com.FNGetStatus();
        //    check.QRData.Fn = com.SerialNumber;

        //    SetError(check, false);

        //    PrintTemplate();

        //    return check;
        //}
    }
}