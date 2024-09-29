

using BudgetData.Domain;

namespace BudgetData.Data
{
    public interface IBudgetRepository
    {
        bool Save(Budget oBudget);
        List<Budget> GetAll();
        Budget? GetById(int id);
        bool Update(Budget oBudget);

    }
}
