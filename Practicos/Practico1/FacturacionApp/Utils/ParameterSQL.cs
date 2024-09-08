using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Utils
{
    public class ParameterSQL
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public ParameterSQL(string name, object value)
        {
            Name = name;
            Value = value;
        }

    }
}
