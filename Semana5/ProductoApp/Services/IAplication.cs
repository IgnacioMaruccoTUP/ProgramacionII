using ProductoApp.Models;

namespace ProductoApp.Services
{
    public interface IAplication
    {
        bool AddOrUpdateProduct(Product oProduct);
        bool DeleteProduct(int code);
        List<Product> GetProducts();
    }
}
