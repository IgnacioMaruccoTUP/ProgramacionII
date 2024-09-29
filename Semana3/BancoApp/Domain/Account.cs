using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Domain
{
    public class Account
    {
        public int Cbu { get; set; }
        public AccountType AccountType { get; set; }
        public float Saldo { get; set; }
        public Client Cliente { get; set; }
        public DateTime UltimoMovimiento { get; set; }

        public override string? ToString()
        {
            return $"CBU: {Cbu} | Tipo de Cuenta: {AccountType} | Saldo: {Saldo} | Cliente: {Cliente} | Ultimo Movimiento: {UltimoMovimiento}";
        }
    }
}
