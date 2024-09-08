using FacturacionApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Repositories.Contracts
{
    public interface IArticleRepository
    {
        List<Article> GetAll();
        bool Add(Article oArticle);
    }
}
