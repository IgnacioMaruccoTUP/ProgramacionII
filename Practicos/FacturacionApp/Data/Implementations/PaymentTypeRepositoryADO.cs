using FacturacionApp.Data.Contracts;
using FacturacionApp.Domain;
using FacturacionApp.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Data.Implementations
{
    public class PaymentTypeRepositoryADO : IPaymentTypeRepository
    {
        private SqlConnection _connection;
        private SqlTransaction _transaction;
        public PaymentTypeRepositoryADO()
        {
            
        }

        public PaymentTypeRepositoryADO(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public List<PaymentType> GetAll()
        {
            DataTable dataTable = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_FORMAS_PAGO", null, _transaction);

            var paymentTypeList = new List<PaymentType>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    var oPaymentType = new PaymentType
                    {
                        Code = Convert.ToInt32(row["id_forma_pago"]),
                        Name = row["forma_pago"].ToString()
                    };
                    paymentTypeList.Add(oPaymentType);
                }
            }
            return paymentTypeList;
        }
    }
}
