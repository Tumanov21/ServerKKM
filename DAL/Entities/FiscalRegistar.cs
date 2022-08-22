using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class FiscalRegistar
    {
        [DataMember] 
        public bool PrintOnlyElectronicChecks { get; set; }

        [DataMember] 
        public string PrintOnlyElectronicChecksDefaultContact { get; set; }
    }
}
