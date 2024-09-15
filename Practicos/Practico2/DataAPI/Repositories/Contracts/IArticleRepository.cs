using DataAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Repositories.Contracts
{
    public interface IArticleRepository
    {
        bool DeleteArticle(int id);
        List<Article> GetAllArticles();
        Article GetArticleById(int id);
        bool SaveArticle(Article article);
    }
}
