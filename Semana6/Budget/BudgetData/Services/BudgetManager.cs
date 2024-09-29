using BudgetData.Data;
using BudgetData.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetData.Services
{
    public class BudgetManager
    {
        private IBudgetRepository _repository;

        public BudgetManager()
        {
            _repository = new BudgetRepository();
        }

        public List<Budget> GetBudgets()
        {
            return _repository.GetAll();
        }

        public Budget? GetBudgetsById(int id)
        {
            return _repository.GetById(id);
        }

        public bool UpdateBudget(Budget p) => _repository.Update(p);
    }
}
