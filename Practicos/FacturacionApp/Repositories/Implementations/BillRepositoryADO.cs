using FacturacionApp.Domain;
using FacturacionApp.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacturacionApp.Repositories.Contracts;

namespace FacturacionApp.Repositories.Implementations
{
    public class BillRepositoryADO : IBillRepository
    {
        public bool Delete(int code)
        {
            var parameters = new List<ParameterSQL>
                {
                    new ParameterSQL("@id_factura", code)
                };

            int affectedRows = DataHelper.GetInstance().ExecuteSPDML("SP_ELIMINAR_FACTURA", parameters);
            return affectedRows > 0;
        }

        public List<Bill> GetAll()
        {
            var billList = new List<Bill>();

            DataTable dataTable = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_FACTURAS_COMPLETA", null);

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
        //    var billList = new List<Bill>();
        //    DataTable dataTable = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_FACTURAS", null);

        //    if (dataTable != null)
        //    {
        //        foreach (DataRow row in dataTable.Rows)
        //        {
        //            var oPaymentType = new PaymentType {
        //                Code = Convert.ToInt32(row["id_forma_pago"]),
        //                Name = row["forma_pago"].ToString()
        //            };
        //            var oBill = new Bill
        //            {
        //                Code = Convert.ToInt32(row["id_factura"]),
        //                Date = Convert.ToDateTime(row["fecha"]),
        //                PaymentType = oPaymentType,
        //                Client = row["cliente"].ToString()
        //            };
        //            billList.Add(oBill);
        //        }
        //    }

        //    return billList;
        //}

        public Bill GetById(int code)
        {
            var parameters = new List<ParameterSQL>
                {
                    new ParameterSQL("@id_factura", code)
                };

            DataTable dataTable = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_FACTURA_POR_CODIGO", parameters);

            Bill oBill = null;

            if (dataTable != null)
            {
                oBill = new Bill
                {
                    Code = Convert.ToInt32(dataTable.Rows[0]["id_factura"]),
                    Date = Convert.ToDateTime(dataTable.Rows[0]["fecha"]),
                    PaymentType = new PaymentType
                    {
                        Name = dataTable.Rows[0]["forma_pago"].ToString()
                    },
                    Client = dataTable.Rows[0]["cliente"].ToString()
                };
                foreach (DataRow row in dataTable.Rows)
                {
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

                    oBill.AddDetail(detail);
                }
            }

            return oBill;
        }

        public bool Save(Bill oBill)
        {
            bool result = true;
            SqlTransaction? transaction = null;
            SqlConnection? connection = null;

            try
            {
                connection = DataHelper.GetInstance().GetConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                var command = new SqlCommand("SP_INSERTAR_FACTURA", connection, transaction);
                command.CommandType = CommandType.StoredProcedure;

                //Parametros de entrada:
                command.Parameters.AddWithValue("@cliente", oBill.Client);
                command.Parameters.AddWithValue("@id_forma_pago", oBill.PaymentType.Code);
                //Parametro de salida:
                SqlParameter outParam = new SqlParameter("@id_factura", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                command.Parameters.Add(outParam);
                command.ExecuteNonQuery();

                int billCode = Convert.ToInt32(outParam.Value);
                int billDetailCode = 1;

                foreach (var detail in oBill.DetailList)
                {
                    var commandDetail = new SqlCommand("SP_INSERTAR_DETALLE", connection, transaction);
                    commandDetail.CommandType = CommandType.StoredProcedure;
                    commandDetail.Parameters.AddWithValue("@id_detalle", billDetailCode);
                    commandDetail.Parameters.AddWithValue("@id_factura", billCode);
                    commandDetail.Parameters.AddWithValue("@id_articulo", detail.Article.Code);
                    commandDetail.Parameters.AddWithValue("@cantidad", detail.Count);

                    commandDetail.ExecuteNonQuery();

                    billDetailCode++;
                }
                transaction.Commit();
            }
            catch (SqlException)
            {
                if (transaction != null)
                {
                    transaction.Rollback();    
                }
                return false;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return result;
        }
    }
}
