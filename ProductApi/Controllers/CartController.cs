using Ecommerce.ProductApi.Models;
using Ecommerce.ProductApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpPost]
        public void AddCart(Cart cart)
        {
            _cartRepository.AddCart(cart);
        }

        [HttpGet("{userId}")]
        public List<Product> GetCartItems(string userId)
        {
            return _cartRepository.GetCartItems(userId);
        }

        [HttpDelete("{productId}/{userId}")]
        public void DeleteItemFromCart(int productId, string userId)
        {
            _cartRepository.DeleteCartItem(productId, userId);
        }

        [HttpDelete("{userId}")]
        public void DeleteCart(string userId)
        {
            _cartRepository.DeleteCart(userId);
        }
    }
}
