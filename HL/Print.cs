using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL
{
    public class Print
    {
        private static dynamic shtrih { get; set; }
        private static dynamic atol { get; set; }
        private static readonly object _shtrih = new object();
        private static readonly object _atol = new object();
        public static dynamic GetShtrihInstance()
        {
            lock (_shtrih)
            {
                if (shtrih == null)
                {
                    Type t = Type.GetTypeFromProgID("AddIn.Drvfr");
                    if (t == null)
                    {
                        throw new Exception("Не удалось найти AddIn.Drvfr. Не установлен драйвер торгового оборудования Штрих 5.х версии. ");
                    }
                    shtrih = Activator.CreateInstance(t);
                    return shtrih;
                }
                else
                    return shtrih;
            }
        }

        public static dynamic GetAtolInstance()
        {
            lock (_atol)
            {
                //   if (atol == null)
                {
                    Type t = Type.GetTypeFromProgID("AddIn.FprnM45");
                    if (t == null)
                    {
                        throw new Exception("Не удалось найти AddIn.FprnM45");
                    }
                    atol = Activator.CreateInstance(t);
                    return atol;
                }
                //   else
                return atol;
            }
        }
    }
}
