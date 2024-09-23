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
    public class BillService : IBillService
    {
        private IBillRepository _repository;

        public BillService()
        {
            _repository = new BillRepositoryADO();
        }

        public bool DeleteBill(int id)
        {
            throw new NotImplementedException();
        }

        public bool EditBill(Bill oBill)
        {
            return _repository.EditBill(oBill);
        }
        public List<Bill> GetBills(DateTime? dateQuery, int? paymentTypeQuery)
        {
            return _repository.GetBills(dateQuery, paymentTypeQuery);
        }
        //public List<Bill> GetAllBills()
        //{
        //    return _repository.GetAllBills();
        //}

        public Bill GetBillById(int id)
        {
            return _repository.GetBillById(id);
        }

        public bool SaveBill(Bill oBill)
        {
            return _repository.SaveBill(oBill);
        }
    }
}
