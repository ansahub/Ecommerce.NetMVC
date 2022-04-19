using Ecommerce.ProductApi.Models;
using ProductApi.Models;
using System.Collections.Generic;

namespace Ecommerce.ProductApi.Repositories
{
    public interface ICartRepository
    {
        int AddCart(Cart cart);
        List<Product> GetCartItems(string userId);
        void DeleteCartItem(int productId, string userId);
        void DeleteCart(string userId);

    }
}