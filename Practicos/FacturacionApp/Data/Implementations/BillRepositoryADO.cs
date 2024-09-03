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
    public class BillRepositoryADO : IBillRepository
    {
        private SqlConnection _connection;
        private SqlTransaction _transaction;
        public BillRepositoryADO() { }

        public BillRepositoryADO(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Bill> GetAll()
        {
            var billList = new List<Bill>();

            DataTable dataTable = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_FACTURAS_COMPLETA", null, _transaction);

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    var billCode = Convert.ToInt32(row["id_factura"]);

                    Bill bill = null;
                    // Busca la factura en la lista
                    for (int i = 0; i < billList.Count; i++)
                    {
                        if (billList[i].Code == billCode)
                        {
                            bill = billList[i];
                            break;
                        }
                    }

                    // Si no existe, la crea y la agrega a la lista
                    if (bill == null)
                    {
                        bill = new Bill
                        {
                            Code = billCode,
                            Date = Convert.ToDateTime(row["fecha"]),
                            PaymentType = new PaymentType
                            {
                                Name = row["forma_pago"].ToString()
                            },
                            Client = row["cliente"].ToString()
                        };
                        billList.Add(bill);
                    }

                    // Agrega detalles a la factura correspondiente
                    var detail = new BillDetail
                    {
                        Code = Convert.ToInt32(row["id_detalle"]),
                        Article = new Article
                        {
                            Name = row["nombre"].ToString(),
                            UnitPrice = Convert.ToDecimal(row["precio_unitario"])
                        },
                        Count = Convert.ToInt32(row["cantidad"])
                    };

                    bill.AddDetail(detail);
                }
            }

            return billList;
        }


        //public List<Bill> GetAll()
        //{
        //    List<Bill> billList = new List<Bill>();
        //    var dataTable = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_FACTURAS", null, _transaction);
        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        int idBill = Convert.ToInt32(row["id_factura"]);
        //        DateTime date = Convert.ToDateTime(row["fecha"]);
        //        PaymentType oPaymentType = new PaymentType();
        //        oPaymentType.Code = Convert.ToInt32(row["id_forma_pago"]);
        //        oPaymentType.Name = row["forma_pago"].ToString();
        //        string client = row["cliente"].ToString();
        //        Bill oBill = new Bill()
        //        {
        //            Code = idBill,
        //            Date = date,
        //            PaymentType = oPaymentType,
        //            Client = client
        //        };
        //        billList.Add(oBill);
        //    }
        //    return billList;
        //}

        public Bill GetById(int id)
        {
            var parameters = new List<ParameterSQL>();
            parameters.Add(new ParameterSQL("@codigo", id));
            DataTable dataTable = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_FACTURA_POR_CODIGO", parameters);

            if (dataTable != null && dataTable.Rows.Count == 1)
            {
                DataRow row = dataTable.Rows[0];
                int idBill = Convert.ToInt32(row["id_factura"]);
                DateTime date = Convert.ToDateTime(row["fecha"]);
                PaymentType oPaymentType = new PaymentType();
                oPaymentType.Code = Convert.ToInt32(row["id_forma_pago"]);
                oPaymentType.Name = row["forma_pago"].ToString();
                string client = row["cliente"].ToString();
                Bill oBill = new Bill()
                {
                    Code = idBill,
                    Date = date,
                    PaymentType = oPaymentType,
                    Client = client
                };
                return oBill;

            }
            return null;
        }

        public bool Save(Bill oBill)
        {
            bool result = true;
            SqlTransaction? transaction = null;
            SqlConnection? cnn = null;

            //Primero el maestro
            var cmd = new SqlCommand("SP_INSERTAR_FACTURA", cnn, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            //Parametro de entrada
            cmd.Parameters.AddWithValue("@id_forma_pago", oBill.PaymentType.Code);
            cmd.Parameters.AddWithValue("@cliente", oBill.Client);

            //Parametro de salida
            SqlParameter outputParameter = new SqlParameter("@id", SqlDbType.Int);
            outputParameter.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParameter);

            cmd.ExecuteNonQuery();

            int idBill = (int)outputParameter.Value;

            int idDetail = 1;
            //Ahora los detalles en la transaccion
            foreach (var oDetail in oBill.DetailList)
            {
                var cmdDetail = new SqlCommand("SP_INSERTAR_DETALLE", cnn, transaction);
                cmdDetail.CommandType = CommandType.StoredProcedure;

                cmdDetail.Parameters.AddWithValue("@id_detalle", idDetail);
                cmdDetail.Parameters.AddWithValue("@id_factura", idBill);
                cmdDetail.Parameters.AddWithValue("@id_articulo", oDetail.Article.Code);
                cmdDetail.Parameters.AddWithValue("@cantidad", oDetail.Count);

                cmdDetail.ExecuteNonQuery();
                idDetail++;
            }
            return result;
        }

        //public bool Save(Bill oBill)
        //{
        //    bool result = true;
        //    SqlTransaction? transaction = null;
        //    SqlConnection? cnn = null;
        //    try
        //    {
        //        cnn = DataHelper.GetInstance().GetConnection();
        //        cnn.Open();

        //        transaction = cnn.BeginTransaction();

        //        //Primero el maestro
        //        var cmd = new SqlCommand("SP_INSERTAR_FACTURA", cnn, transaction);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        //Parametro de entrada
        //        cmd.Parameters.AddWithValue("@id_forma_pago", oBill.PaymentType.Code);
        //        cmd.Parameters.AddWithValue("@cliente", oBill.Client);

        //        //Parametro de salida
        //        SqlParameter outputParameter = new SqlParameter("@id", SqlDbType.Int);
        //        outputParameter.Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add(outputParameter);

        //        cmd.ExecuteNonQuery();

        //        int idBill = (int)outputParameter.Value;

        //        int idDetail = 1;
        //        //Ahora los detalles en la transaccion
        //        foreach (var oDetail in oBill.DetailList)
        //        {
        //            var cmdDetail = new SqlCommand("SP_INSERTAR_DETALLE", cnn, transaction);
        //            cmdDetail.CommandType = CommandType.StoredProcedure;

        //            cmdDetail.Parameters.AddWithValue("@id_detalle", idDetail);
        //            cmdDetail.Parameters.AddWithValue("@id_factura", idBill);
        //            cmdDetail.Parameters.AddWithValue("@id_articulo", oDetail.Article.Code);
        //            cmdDetail.Parameters.AddWithValue("@cantidad", oDetail.Count);

        //            cmdDetail.ExecuteNonQuery();
        //            idDetail++;
        //        }
        //        transaction.Commit();
        //    }
        //    catch (SqlException)
        //    {
        //        if (transaction != null)
        //        {
        //            transaction.Rollback();
        //        }
        //        result = false;
        //    }
        //    finally
        //    {
        //        if (cnn != null && cnn.State == ConnectionState.Open)
        //        {
        //            cnn.Close();
        //        }

        //    }
        //    return result;
        //}
    }
}
