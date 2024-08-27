using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Domain
{
    public class Cuenta
    {
        public int Cbu { get; set; }
        public TipoCuenta TipoCuenta { get; set; }
        public float Saldo { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime UltimoMovimiento { get; set; }

        public override string? ToString()
        {
            return $"CBU: {Cbu} | Tipo de Cuenta: {TipoCuenta} | Saldo: {Saldo} | Cliente: {Cliente} | Ultimo Movimiento: {UltimoMovimiento}";
        }
    }
}
