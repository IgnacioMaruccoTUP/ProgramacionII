using ProductoApp.Models;

namespace ProductoApp.Services
{
    public class ProductService : IAplication
    {
        public static readonly List<Product> listaProductos = new List<Product>();

        public List<Product> GetProducts()
        {
            return listaProductos;
        }

        public bool AddOrUpdateProduct(Product oProduct)
        {

            foreach (Product product in listaProductos)
            {
                if (oProduct.Code == product.Code)
                {
                    product.Name = oProduct.Name;
                    product.Price = oProduct.Price;
                    return true;
                }
            }

            if (oProduct == null)
                return false;

            listaProductos.Add(oProduct);
            return true;
        }

        public bool DeleteProduct(int code)
        {
            var product = listaProductos.Find(p =>  p.Code == code);

            if (product == null)
                return false;

            listaProductos.Remove(product);
            return true;


        }            
    }
}
