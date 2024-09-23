using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Utils
{
    public class DataHelper
    {
        private static DataHelper _instance;
        private SqlConnection _connection;

        private DataHelper()
        {
            _connection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=FacturacionII;Integrated Security=True;TrustServerCertificate=True");
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

        public DataTable ExecuteSPQuery(string SP, List<SqlParameter>? parameters = null)
        {
            DataTable dataTable = new DataTable();
            SqlCommand cmd = null;

            try
            {
                _connection.Open();
                cmd = new SqlCommand(SP, _connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                        cmd.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                }

                dataTable.Load(cmd.ExecuteReader());
            }
            catch (SqlException)
            {
                dataTable = null;
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return dataTable;
        }

        public int ExecuteSPDML(string sp, List<SqlParameter>? parameters)
        {
            int rows;
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                        cmd.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                }

                rows = cmd.ExecuteNonQuery();
                _connection.Close();
            }
            catch (SqlException)
            {
                rows = 0;
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

            return rows;
        }
    }
}
