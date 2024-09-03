using FacturacionApp.Data.Implementations;
using FacturacionApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Services
{
    public class BillManager
    {
        private readonly UnitOfWork _unitOfWork;

        public BillManager(UnitOfWork oUnitOfWork)
        {
            _unitOfWork = oUnitOfWork;
        }

        public List<Article> GetAllArticles()
        {
            return _unitOfWork.ArticleRepositoryADO.GetAll();
        }

        public List<PaymentType> GetAllPaymentTypes()
        {
            return _unitOfWork.PaymentTypeRepositoryADO.GetAll();
        }

        public List<Bill> GetAllBills()
        {
            return _unitOfWork.BillRepositoryADO.GetAll();
        }

        public bool AddBill(Bill bill)
        {
            var result = _unitOfWork.BillRepositoryADO.Save(bill);
            return result;
        }
        public void GuardarCambios()
        {
            _unitOfWork.SaveChanges();
        }
    }
}
