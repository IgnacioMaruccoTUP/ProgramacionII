using FacturacionApp.Domain;
using FacturacionApp.Repositories.Contracts;
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
        public List<Article> GetAll()
        {
            DataTable dataTable = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_ARTICULOS", null);
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

        public bool Add(Article oArticle)
        {
            var parametros = new List<ParameterSQL>
            {
                new ParameterSQL("@nombre", oArticle.Name),
                new ParameterSQL("@precio_unitario", oArticle.UnitPrice),
            };

            int filasAfectadas = DataHelper.GetInstance().ExecuteSPDML("SP_CREAR_ARTICULO", parametros);
            return filasAfectadas > 0;
        }
    }
}
