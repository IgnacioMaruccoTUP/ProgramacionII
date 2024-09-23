using DataAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Repositories.Contracts
{
    public interface IBillRepository
    {
        bool EditBill(Bill oBill);
        //List<Bill> GetAllBills();
        List<Bill> GetBills(DateTime? dateQuery, int? paymentTypeQuery);
        Bill GetBillById(int id);
        bool SaveBill(Bill oBill);
    }
}
