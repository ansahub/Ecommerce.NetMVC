using Ecommerce.ProductApi;
using Ecommerce.ProductApi.Repositories;
using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        IDbContextGenerator _dbContextGenerator;
        IDatabaseContext _databaseContext;
        ICartRepository _cartRepository;

        public OrderRepository(IDbContextGenerator dbContextGenerator, ICartRepository cartrepository)
        {
            _databaseContext = dbContextGenerator.GenerateMyDbContext();
            _dbContextGenerator = dbContextGenerator;
            _cartRepository = cartrepository;
        }
     

        public int AddOrderFromCart(string userId)
        {
            var cartItems = _cartRepository.GetCartItems(userId);
            List<Order> orderList = new List<Order>();

            foreach (var cartItem in cartItems)
            {
                orderList.Add(new Order { ProductId = cartItem.ProductId, UserId = userId });
            }

            _databaseContext.Orders.AddRange(orderList);

            return _databaseContext.SaveChanges();
        }

        
    }
}
