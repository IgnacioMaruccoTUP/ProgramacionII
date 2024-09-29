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
    public class AccountRepositoryADO : IAccountRepository
    {
        //CRUD
        //llamar metodo del helper para conectar con BD
        //mapear

        private SqlConnection _connection;

        public AccountRepositoryADO()
        {
            _connection = new SqlConnection(Properties.Resources.cnnStringUTN);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Account>? GetAll()
        {
            List<Account> listCuentas = new List<Account>();

            var helper = DataHelper.GetInstance();
            var dataTable = helper.ExecuteSPQuery("RecuperarCuentas", null);

            if (dataTable == null)
            {
                Console.WriteLine("No hay cuentas en la Base de Datos");
                return null;
            }

            foreach (DataRow row in dataTable.Rows)
            {
                int cbu = Convert.ToInt32(row["cbu"]);
                float saldo = Convert.ToInt32(row["saldo"]);
                AccountType oAccountType = new AccountType();
                oAccountType.Id = Convert.ToInt32(row["id_tipo_cuenta"]);
                oAccountType.Nombre = row["tipo_cuenta"].ToString();
                Client oClient = new Client();
                oClient.Id = Convert.ToInt32(row["id_cliente"]);
                oClient.Dni = Convert.ToInt32(row["dni"]);
                oClient.Apellido = row["apellido"].ToString();
                oClient.Nombre = row["nombre"].ToString();
                DateTime ultimo_movimiento = (DateTime)row["ultimo_movimiento"];

                Account oCuenta = new Account()
                {
                    Cbu = cbu,
                    Saldo = saldo,
                    AccountType = oAccountType,
                    Cliente = oClient,
                    UltimoMovimiento = ultimo_movimiento
                };
                listCuentas.Add(oCuenta);
            }
            return listCuentas;
        }

        public bool Save(Account oCuenta)
        {
            throw new NotImplementedException();
        }

        public Account GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
