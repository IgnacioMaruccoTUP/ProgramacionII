using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Domain
{
    public class Client
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }

        public override string? ToString()
        {
            return $"{Apellido}, {Nombre} - DNI: {Dni}";
        }
    }
}
