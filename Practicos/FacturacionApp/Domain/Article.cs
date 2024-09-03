﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Domain
{
    public class Article
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }

        public override string? ToString()
        {
            return $"Codigo: {Code} | Nombre: {Name} | Precio Unitario: {UnitPrice}";
        }
    }
}
