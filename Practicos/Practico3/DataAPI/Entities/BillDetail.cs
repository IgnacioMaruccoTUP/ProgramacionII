using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Entities
{
    public class BillDetail
    {
        public int Code { get; set; }
        public int BillCode { get; set; }
        public Article Article { get; set; }
        public int Count { get; set; }

        public decimal SubTotal()
        {
            return Count * Article.UnitPrice;
        }
    }
}
