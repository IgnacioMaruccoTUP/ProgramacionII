using DataAPI.Entities;
using DataAPI.Repositories.Contracts;
using DataAPI.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Repositories.Implementations
{
    public class BillRepositoryADO : IBillRepository
    {
        public bool EditBill(Bill oBill)
        {
            bool result = true;
            SqlTransaction? t = null;
            SqlConnection? cnn = null;

            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();
                t = cnn.BeginTransaction();

                var cmd = new SqlCommand("SP_EDITAR_FACTURA", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;

                //parámetro de entrada:
                cmd.Parameters.AddWithValue("@id_factura", oBill.Code);
                cmd.Parameters.AddWithValue("@fecha", oBill.Date);
                cmd.Parameters.AddWithValue("@cliente", oBill.Client);
                cmd.Parameters.AddWithValue("@id_forma_pago", oBill.PaymentType.Code);
                cmd.Parameters.AddWithValue("@activo", oBill.Active);

                cmd.ExecuteNonQuery();



                int nroDetail = 1;
                foreach (var detail in oBill.DetailList)
                {
                    var cmdDetail = new SqlCommand("SP_INSERTAR_DETALLE", cnn, t);
                    cmdDetail.CommandType = CommandType.StoredProcedure;
                    cmdDetail.Parameters.AddWithValue("@id_factura", oBill.Code);
                    cmdDetail.Parameters.AddWithValue("@id_detalle", nroDetail);
                    cmdDetail.Parameters.AddWithValue("@id_articulo", detail.Article.Code);
                    cmdDetail.Parameters.AddWithValue("@cantidad", detail.Count);
                    cmdDetail.ExecuteNonQuery();
                    nroDetail++;
                }

                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null)
                {
                    t.Rollback();
                }
                result = false;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return result;
        }

        public List<Bill> GetBills(DateTime? dateQuery, int? paymentTypeQuery)
        {
            List<Bill> billList = new List<Bill>();
            Bill? oBill = null;
            var helper = DataHelper.GetInstance();
            List<SqlParameter> parameterList = new List<SqlParameter>();


            //Validar valores que pueden ser nulos en los parametros del SP
            if (!dateQuery.HasValue)
                parameterList.Add(new SqlParameter("@fecha", DBNull.Value));
            else
                parameterList.Add(new SqlParameter("@fecha", dateQuery));

            if (!paymentTypeQuery.HasValue)
                parameterList.Add(new SqlParameter("@id_forma_pago", DBNull.Value));
            else
                parameterList.Add(new SqlParameter("@id_forma_pago", paymentTypeQuery));

            var dataTable = helper.ExecuteSPQuery("SP_RECUPERAR_FACTURAS_FILTRADAS", parameterList);
            foreach (DataRow row in dataTable.Rows)
            {
                //leer la primer fila y tomar datos del maestro y primer detalle
                if (oBill == null || oBill.Code != Convert.ToInt32(row["id_factura"].ToString()))
                {
                    oBill = new Bill();

                    oBill.Code = Convert.ToInt32(row["id_factura"].ToString());
                    oBill.Client = row["cliente"].ToString();
                    oBill.Date = Convert.ToDateTime(row["fecha"].ToString());
                    oBill.Active = Convert.ToBoolean(row["activo"].ToString());
                    PaymentType oPaymentType = new PaymentType();
                    oPaymentType.Code = Convert.ToInt32(row["id_forma_pago"].ToString());
                    oPaymentType.Name = row["forma_pago"].ToString();
                    oBill.PaymentType = oPaymentType;

                    oBill.AddDetail(ReadDetail(row));

                    billList.Add(oBill);
                }
                else
                {
                    //mientras no cambia el Id del maestro, leer datos de detalles.
                    oBill.AddDetail(ReadDetail(row));
                }
            }
            return billList;
        }

        //public List<Bill> GetAllBills()
        //{
        //    List<Bill> billList = new List<Bill>();
        //    Bill? oBill = null;
        //    var helper = DataHelper.GetInstance();
        //    List<SqlParameter> parameterList = new List<SqlParameter>();

        //    var dataTable = helper.ExecuteSPQuery("SP_RECUPERAR_FACTURAS", parameterList);
        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        //leer la primer fila y tomar datos del maestro y primer detalle
        //        if (oBill == null || oBill.Code != Convert.ToInt32(row["id_factura"].ToString()))
        //        {
        //            oBill = new Bill();

        //            oBill.Code = Convert.ToInt32(row["id_factura"].ToString());
        //            oBill.Client = row["cliente"].ToString();
        //            oBill.Date = Convert.ToDateTime(row["fecha"].ToString());
        //            oBill.Active = Convert.ToBoolean(row["activo"].ToString());
        //            PaymentType oPaymentType = new PaymentType();
        //            oPaymentType.Code = Convert.ToInt32(row["id_forma_pago"].ToString());
        //            oPaymentType.Name = row["forma_pago"].ToString();
        //            oBill.PaymentType = oPaymentType;

        //            oBill.AddDetail(ReadDetail(row));

        //            billList.Add(oBill);
        //        }
        //        else
        //        {
        //            //mientras no cambia el Id del maestro, leer datos de detalles.
        //            oBill.AddDetail(ReadDetail(row));
        //        }
        //    }
        //    return billList;
        //}

        //función auxiliar para leer un detalle.
        private BillDetail ReadDetail(DataRow row)
        {
            BillDetail oBillDetail = new BillDetail();
            oBillDetail.BillCode = Convert.ToInt32(row["id_factura"].ToString());
            oBillDetail.Code = Convert.ToInt32(row["id_detalle"].ToString());
            oBillDetail.Article = new Article
            {
                Code = Convert.ToInt32(row["id_articulo"].ToString()),
                Name = row["nombre"].ToString(),
                UnitPrice = Convert.ToDecimal(row["precio_unitario"].ToString()),
                Active = Convert.ToBoolean(row["activo"].ToString())
            };
            oBillDetail.Count = Convert.ToInt32(row["cantidad"].ToString());
            return oBillDetail;
        }

        public Bill GetBillById(int id)
        {
            Bill? oBill = null;
            var helper = DataHelper.GetInstance();
            var parameter = new SqlParameter("@id_factura", id);
            var parameterList = new List<SqlParameter>();
            parameterList.Add(parameter);

            var t = helper.ExecuteSPQuery("SP_RECUPERAR_FACTURA_POR_CODIGO", parameterList);
            foreach (DataRow row in t.Rows)
            {
                if (oBill == null)
                {
                    oBill = new Bill();
                    oBill.Code = Convert.ToInt32(row["id_factura"].ToString());
                    oBill.Date = Convert.ToDateTime(row["fecha"].ToString());
                    PaymentType oPaymentType = new PaymentType();
                    oPaymentType.Code = Convert.ToInt32(row["id_forma_pago"].ToString());
                    oPaymentType.Name = row["forma_pago"].ToString();
                    oBill.PaymentType = oPaymentType;

                    oBill.Client = row["cliente"].ToString();
                    oBill.Active = Convert.ToBoolean(row["activo"].ToString());

                    oBill.AddDetail(ReadDetail(row));
                }
                else
                    oBill.AddDetail(ReadDetail(row));
            }
            return oBill;
        }

        public bool SaveBill(Bill oBill)
        {
            bool result = true;
            SqlTransaction? t = null;
            SqlConnection? cnn = null;

            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();
                t = cnn.BeginTransaction();

                var cmd = new SqlCommand("SP_INSERTAR_FACTURA", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;

                //parámetro de entrada:
                cmd.Parameters.AddWithValue("@cliente", oBill.Client);
                //cmd.Parameters.AddWithValue("@fecha", oBill.Date);
                cmd.Parameters.AddWithValue("@activo", true);
                cmd.Parameters.AddWithValue("@id_forma_pago", oBill.PaymentType.Code);
                //parámetro de salida:
                SqlParameter param = new SqlParameter("@id_factura", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                int idBill = (int)param.Value;

                int idDetail = 1;
                foreach (var detail in oBill.DetailList)
                {
                    var cmdDetail = new SqlCommand("SP_INSERTAR_DETALLE", cnn, t);
                    cmdDetail.CommandType = CommandType.StoredProcedure;
                    cmdDetail.Parameters.AddWithValue("@id_factura", idBill);
                    cmdDetail.Parameters.AddWithValue("@id_detalle", idDetail);
                    cmdDetail.Parameters.AddWithValue("@id_articulo", detail.Article.Code);
                    cmdDetail.Parameters.AddWithValue("@cantidad", detail.Count);
                    cmdDetail.ExecuteNonQuery();
                    idDetail++;
                }

                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null)
                {
                    t.Rollback();
                }
                result = false;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return result;
        }
    }
}
