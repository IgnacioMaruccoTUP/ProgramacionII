using DataAPI.Entities;
using DataAPI.Repositories.Contracts;
using DataAPI.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Services
{
    public class ArticleService : IArticleService
    {
        private IArticleRepository _repository;

        public ArticleService()
        {
            _repository = new ArticleRepositoryADO();
        }
        public bool DeleteArticle(int id)
        {
            return _repository.DeleteArticle(id);
        }

        public List<Article> GetAllArticles()
        {
            return _repository.GetAllArticles();
        }

        public Article GetArticleById(int id)
        {
            return _repository.GetArticleById(id);
        }

        public bool SaveArticle(Article article)
        {
            return _repository.SaveArticle(article);
        }
    }
}
