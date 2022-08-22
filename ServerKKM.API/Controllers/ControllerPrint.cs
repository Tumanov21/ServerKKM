using DAL.Entities;
using HL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ServerKKM.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControllerPrint : ControllerBase
    {
        private readonly KKMConnection _kKM;
        public string ErrorDescription { get; set; }
        public int MyProperty { get; set; }

        public ControllerPrint(KKMConnection kKM)
        {
            _kKM = kKM;
        }

        private static dynamic com { get; set; }

        //[HttpPost]
        //public async Task<Print> Test()
        //{
        //}



        [HttpPost("Test")]
        public int TestKKM()
        {
            _kKM.comPort = 20;
            _kKM.baudRate = 6;
            _kKM.timeout = 184;
            var num = _kKM.LoadDriver();
            if (num==0)
            {
                return _kKM.Connect();
            }
            return _kKM.resultCode;
        }

        [HttpPost("TestPrintCheck")]
        public string PrintCheckTest(Check check)
        {
            var ans = new Answer();
            int result = _kKM.PrintCheck(check);
            ans.ResultCode = result;
            if (result != 0)
                ans.ResultDescription = _kKM.resultDescription;
            else
            {
                ans.Body = new AnswerPrintCheck(check.CheckNumber, check.fiscalSign, check.FiscalSignAsString);
            }
            string json = JsonConvert.SerializeObject(ans);
            return json;
        }

        public class Answer
        {
            [JsonProperty("ResultCode")]
            public int ResultCode { get; set; }

            [JsonProperty("ResultDescription")]
            public string ResultDescription { get; set; }

            [JsonProperty("Body")]
            public object Body { get; set; }
        }
        public class AnswerPrintCheck
        {
            public int DocNumber { get; set; }
            public int FiscalSign { get; set; }
            public string FiscalSignStr { get; set; }

            public AnswerPrintCheck(int docNumber, int fiscalSign, string fiscalSignStr)
            {
                FiscalSignStr = fiscalSignStr;
                DocNumber = docNumber;
                FiscalSign = fiscalSign;
            }
        }
    }
}
