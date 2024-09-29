using BudgetData.Domain;

namespace BudgetData.Data
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        bool Save(Product oProduct);
        bool Delete(int id);
    }
}
