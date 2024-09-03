using FacturacionApp.Data.Contracts;
using FacturacionApp.Domain;
using FacturacionApp.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Data.Implementations
{
    public class ArticleRepositoryADO : IArticleRepository
    {
        private SqlConnection _connection;
        private SqlTransaction _transaction;
        public ArticleRepositoryADO(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }
        public List<Article> GetAll()
        {
            DataTable dataTable = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_ARTICULOS", null, _transaction);
            var articleList = new List<Article>();

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    var oArticle = new Article
                    {
                        Code = Convert.ToInt32(row["id_articulo"]),
                        Name = row["nombre"].ToString(),
                        UnitPrice = Convert.ToDecimal(row["precio_unitario"])
                    };
                    articleList.Add(oArticle);
                }
            }
            return articleList;
        }
    }
}
