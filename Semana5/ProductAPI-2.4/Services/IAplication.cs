using ProductAPI.Models;

namespace ProductAPI.Services
{
    public interface IAplication
    {
        bool AddOrUpdateProduct(Product oProduct);
        bool DeleteProduct(int code);
        List<Product> GetProducts();
        Product GetProduct(int code);
    }
}
