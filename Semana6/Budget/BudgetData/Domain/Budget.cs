﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetData.Domain
{
    public class Budget
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Client { get; set; }

        public int Expiration { get; set; }

        //...más atributos
        public List<DetailBudget>  Details{ get; set; }

        

        public List<DetailBudget> GetDetails() {
            return Details;
        }

        public Budget()
        {
            Details = new List<DetailBudget>();
        }

        public void AddDetail(DetailBudget detail)
        {
            if (detail != null)
                Details.Add(detail);
        }

        public void Remove(int index)
        {
            Details.RemoveAt(index);
        }

        public float Total()
        {
            float total = 0;
            foreach (var detail in Details)
                total += detail.SubTotal();

            return total;
        }

    }
}
