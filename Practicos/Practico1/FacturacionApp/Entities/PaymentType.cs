using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Domain
{
    public class PaymentType
    {
        public int Code { get; set; }
        public string Name { get; set; }

        public override string? ToString()
        {
            return Name;
        }

    }
}
