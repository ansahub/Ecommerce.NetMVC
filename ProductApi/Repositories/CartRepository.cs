using Ecommerce.ProductApi.Models;
using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ProductApi.Repositories
{
    public class CartRepository : ICartRepository
    {

        IDbContextGenerator _dbContextGenerator;
        IDatabaseContext _databaseContext;

        public CartRepository(IDbContextGenerator contextGenerator)
        {
            _dbContextGenerator = contextGenerator;
            _databaseContext = _dbContextGenerator.GenerateMyDbContext();
        }

        public int AddCart(Cart cart)
        {
            _databaseContext.Carts.Add(cart);

            return _databaseContext.SaveChanges();
        }


        public List<Product> GetCartItems(string userId)
        {
            var result = from x in _databaseContext.Products join y in _databaseContext.Carts on x.ProductId equals y.ProductId
                         where y.UserId == userId select x;

            return result.OrderBy(x => x.ProductId).ToList();
        }

        public void DeleteCartItem(int productId, string userId) 
        {
           var productToDelete = _databaseContext.Carts.Remove( 
               _databaseContext.Carts.Where(x => x.ProductId == productId && x.UserId == userId).FirstOrDefault());

            _databaseContext.SaveChanges();
        }

        public void DeleteCart(string userId)
        {
            var cartFromUser = _databaseContext.Carts.Where(x => x.UserId == userId).ToList();
            _databaseContext.Carts.RemoveRange(cartFromUser);                      

            _databaseContext.SaveChanges();
        }

    }
}
