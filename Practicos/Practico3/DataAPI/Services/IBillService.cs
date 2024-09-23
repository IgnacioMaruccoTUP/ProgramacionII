using DataAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Services
{
    public interface IBillService
    {
        bool DeleteBill(int id);
        bool EditBill(Bill oBill);
        //List<Bill> GetAllBills();
        List<Bill> GetBills(DateTime? dateQuery, int? paymentTypeQuery);
        Bill GetBillById(int id);
        bool SaveBill(Bill oBill);
    }
}
