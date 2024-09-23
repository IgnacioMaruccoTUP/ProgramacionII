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
    public class ArticleRepositoryADO : IArticleRepository
    {
        public bool DeleteArticle(int id)
        {
            List<SqlParameter> lstParameters = new List<SqlParameter>();
            lstParameters.Add(new SqlParameter("@id_articulo", id));

            return DataHelper.GetInstance().ExecuteSPDML("SP_BAJA_ARTICULO", lstParameters) == 1;
        }

        public bool EditArticle(Article oArticle)
        {
            List<SqlParameter> lstParameters = new List<SqlParameter>();
            lstParameters.Add(new SqlParameter("@id_articulo", oArticle.Code));
            lstParameters.Add(new SqlParameter("@nombre", oArticle.Name));
            lstParameters.Add(new SqlParameter("@precio_unitario", oArticle.UnitPrice));
            lstParameters.Add(new SqlParameter("@activo", oArticle.Active));

            return DataHelper.GetInstance().ExecuteSPDML("SP_EDITAR_ARTICULO", lstParameters) == 1;
        }

        public List<Article> GetAllArticles()
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
                        UnitPrice = Convert.ToDecimal(row["precio_unitario"]),
                        Active = Convert.ToBoolean(row["activo"])
                    };
                    articleList.Add(oArticle);
                }
            }
            return articleList;
        }

        public Article GetArticleById(int id)
        {
            List<SqlParameter> lstParameters = new List<SqlParameter>();
            lstParameters.Add(new SqlParameter("@id_articulo", id));

            DataTable dataTable = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_ARTICULO_POR_CODIGO", lstParameters);

            Article oArticle = null;
            if (dataTable != null && dataTable.Rows.Count == 1)
            {
                oArticle = new Article();
                oArticle.Code = Convert.ToInt32(dataTable.Rows[0]["id_articulo"]);
                oArticle.Name = dataTable.Rows[0]["nombre"].ToString();
                oArticle.UnitPrice = Convert.ToDecimal(dataTable.Rows[0]["precio_unitario"]);
                oArticle.Active = Convert.ToBoolean(dataTable.Rows[0]["activo"]);
            }
            return oArticle;
        }

        public bool SaveArticle(Article oArticle)
        {
            var lstParameters = new List<SqlParameter>
            {
                new SqlParameter("@nombre", oArticle.Name),
                new SqlParameter("@precio_unitario", oArticle.UnitPrice),
                new SqlParameter("activo", oArticle.Active)
            };

            int affectedRows = DataHelper.GetInstance().ExecuteSPDML("SP_INSERTAR_ARTICULO", lstParameters);
            return affectedRows > 0;
        }
    }
}
