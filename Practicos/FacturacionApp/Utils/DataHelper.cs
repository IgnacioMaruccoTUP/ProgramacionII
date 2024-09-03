using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Utils
{
    public class DataHelper
    {
        private static DataHelper _instance;
        private SqlConnection _connection;

        private DataHelper()
        {
            _connection = new SqlConnection(Properties.Resources.cnnStringLocal);
        }

        public static DataHelper GetInstance()
        {
            if (_instance == null)
                _instance = new DataHelper();

            return _instance;
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }

        public DataTable ExecuteSPQuery(string sp, List<ParameterSQL>? parametros)
        {
            DataTable t = new DataTable();
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (var param in parametros)
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                }

                t.Load(cmd.ExecuteReader());
                _connection.Close();
            }
            catch (SqlException)
            {
                t = null;
            }

            return t;
        }

        public DataTable ExecuteSPQuery(string sp, List<ParameterSQL>? parameters, SqlTransaction transaction = null)
        {
            DataTable dataTable = new DataTable();
            SqlCommand cmd = null;

            cmd = new SqlCommand(sp, _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            if (transaction != null)
                cmd.Transaction = transaction;

            if (parameters != null)
            {
                foreach (var param in parameters)
                    cmd.Parameters.AddWithValue(param.Name, param.Value);
            }
            dataTable.Load(cmd.ExecuteReader());

            return dataTable;
        }


        //public DataTable ExecuteSPQuery(string sp, List<ParameterSQL>? parameters, SqlTransaction transaction = null)
        //{
        //    DataTable dataTable = new DataTable();
        //    SqlCommand cmd = null;

        //    try
        //    {
        //        _connection.Open(); 
        //        cmd = new SqlCommand(sp, _connection);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        if (transaction != null)
        //            cmd.Transaction = transaction;

        //        if (parameters != null)
        //        {
        //            foreach (var param in parameters)
        //                cmd.Parameters.AddWithValue(param.Name, param.Value);
        //        }
        //        dataTable.Load(cmd.ExecuteReader());

        //    }
        //    catch (SqlException)
        //    {
        //        dataTable = null;
        //    }
        //    finally
        //    {
        //        if (transaction == null && _connection.State == System.Data.ConnectionState.Open)
        //            _connection.Close();
        //    }

        //    return dataTable;
        //}


        public int ExecuteSPDML(string sp, List<ParameterSQL>? parametros)
        {
            int rows;
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (var param in parametros)
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                }

                rows = cmd.ExecuteNonQuery();
                _connection.Close();
            }
            catch (SqlException)
            {
                rows = 0;
            }

            return rows;
        }
    }
}
