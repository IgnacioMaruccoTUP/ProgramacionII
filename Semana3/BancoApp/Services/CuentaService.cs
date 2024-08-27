using BancoApp.Data;
using BancoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Services
{
    public class CuentaService
    {
        //clase intermediaria
        private ICuentaRepository _repositorio;

        public CuentaService()
        {
            _repositorio = new CuentaRepositoryADO();
        }

        public List<Cuenta> GetCuentas()
        {
            return _repositorio.GetAll();
        }
    }
}
