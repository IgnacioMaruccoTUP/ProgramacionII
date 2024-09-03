using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Domain
{
    public class Bill
    {
        public int Code { get; set; }
        public DateTime Date { get; set; }
        public PaymentType PaymentType { get; set; }
        public string Client { get; set; }

        public List<BillDetail> DetailList { get; set; }

        public Bill()
        {
            DetailList = new List<BillDetail>();
        }

        public void AddDetail(BillDetail oDetail)
        {
            if (oDetail != null)
                DetailList.Add(oDetail);
        }

        public void RemoveDetail(int detailIndex)
        {
            DetailList.RemoveAt(detailIndex);
        }

        public decimal Total()
        {
            decimal total = 0;
            foreach (var oDetail in DetailList)
            {
                total += oDetail.SubTotal();
            }
            return total;
        }
    }
}
