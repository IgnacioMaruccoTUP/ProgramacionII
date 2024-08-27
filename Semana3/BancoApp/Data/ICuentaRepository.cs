using BancoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Data
{
    public interface ICuentaRepository
    {
        bool Save(Cuenta oCuenta);
        List<Cuenta> GetAll();
    }
}
