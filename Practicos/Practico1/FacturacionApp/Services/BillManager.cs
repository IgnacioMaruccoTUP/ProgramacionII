using FacturacionApp.Data.Implementations;
using FacturacionApp.Domain;
using FacturacionApp.Repositories.Contracts;
using FacturacionApp.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Services
{
    public class BillManager
    {
        IArticleRepository articleRepository;
        IPaymentTypeRepository paymentTypeRepository;
        IBillRepository billRepository;
        public BillManager()
        {
            articleRepository = new ArticleRepositoryADO();
            paymentTypeRepository = new PaymentTypeRepositoryADO();
            billRepository = new BillRepositoryADO();
        }
        public List<PaymentType> GetAllPaymentTypes()
        {
            return paymentTypeRepository.GetAll();
        }
        public List<Article> GetAllArticles()
        {
            return articleRepository.GetAll();
        }
        public bool AddArticle(Article oArticle)
        {
            return articleRepository.Add(oArticle);
        }

        public bool DeleteBill(int code)
        {
            return billRepository.Delete(code);
        }

        public List<Bill> GetAllBills()
        {
            return billRepository.GetAll();
        }

        public bool SaveBill(Bill oBill)
        {
            return billRepository.Save(oBill);
        }

        public Bill GetBillById(int code)
        {
            return billRepository.GetById(code);
        }
    }
}
