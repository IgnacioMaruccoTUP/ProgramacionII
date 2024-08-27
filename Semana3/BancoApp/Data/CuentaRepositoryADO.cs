using BancoApp.Data.Utils;
using BancoApp.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Data
{
    public class CuentaRepositoryADO : ICuentaRepository
    {
        //CRUD
        //llamar metodo del helper para conectar con BD
        //mapear

        private SqlConnection _connection;

        public CuentaRepositoryADO()
        {
            _connection = new SqlConnection(Properties.Resources.cnnStringUTN);
        }

        public List<Cuenta> GetAll()
        {
            List<Cuenta> listCuentas = new List<Cuenta>();

            var helper = DataHelper.GetInstance();
            var dataTable = helper.ExecuteSPQuery("RecuperarCuentas", null);

            foreach (DataRow row in dataTable.Rows)
            {
                int cbu = Convert.ToInt32(row["cbu"]);
                float saldo = Convert.ToInt32(row["saldo"]);
                TipoCuenta oTipoCuenta = new TipoCuenta();
                oTipoCuenta.Id = Convert.ToInt32(row["id_tipo_cuenta"]);
                Cliente oCliente = new Cliente();
                oCliente.Id = Convert.ToInt32(row["id_cliente"]);
                DateTime ultimo_movimiento = (DateTime)row["ultimo_movimiento"];

                Cuenta oCuenta = new Cuenta()
                {
                    Cbu = cbu,
                    Saldo = saldo,
                    TipoCuenta = oTipoCuenta,
                    Cliente = oCliente,
                    UltimoMovimiento = ultimo_movimiento
                };
                listCuentas.Add(oCuenta);
            }
            return listCuentas;
        }

        public bool Save(Cuenta oCuenta)
        {
            throw new NotImplementedException();
        }
    }
}
