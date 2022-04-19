using Ecommerce.ProductApi.Models;
using System.Collections.Generic;

namespace Ecommerce.ProductApi.Repositories
{
    public interface IProductRepository
    {
        //Product GetProductById(int id);
        List<Product> GetProducts();
        int AddProduct(Product product);
        Product GetProductById(int v);
    }
}