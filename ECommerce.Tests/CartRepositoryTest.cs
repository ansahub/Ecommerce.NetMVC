using Ecommerce.ProductApi;
using Ecommerce.ProductApi.Models;
using Ecommerce.ProductApi.Repositories;
using Moq;
using NUnit.Framework;
using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Web.Tests
{
    public class CartRepositoryTest{ 

        IDbContextGenerator _dbContextGenerator;
        ICartRepository _cartRepository;

        List<Cart> CartList = new List<Cart>();
        List<Product> Products = new List<Product>();
        Mock<IDatabaseContext> mockDb = new Mock<IDatabaseContext>();

        //1. Mocking a list of Cart
        Cart Item1 = new() { CartId = 1, ProductId = 1 , UserId = "123",  };
        Cart Item2 = new() { CartId = 2, ProductId = 5, UserId = "456", };

        //2. Mocking a list of Product
        Product regular = new() { ProductId = 1, ProductName = "Basic White", ProductPrice = 129, CategoryId = 1 };
        Product patterns = new() { ProductId = 5, ProductName = "Flowers", ProductPrice = 199, CategoryId = 3 };


        [SetUp]
        public void Setup()
        {
            CartList.Add(Item1);
            CartList.Add(Item2);

            Products.Add(regular);
            Products.Add(patterns);
            
            //Create context mock
            mockDb.Setup(x => x.Carts).Returns(DbContextMock.GetMockDbSet<Cart>(CartList));
            mockDb.Setup(x => x.Products).Returns(DbContextMock.GetMockDbSet<Product>(Products));
            mockDb.Setup(x => x.SaveChanges()).Returns(3);

            var mock = new Mock<IDbContextGenerator>();
            mock.Setup(x => x.GenerateMyDbContext()).Returns(mockDb.Object);

            _cartRepository= new CartRepository(mock.Object);
            

            _dbContextGenerator = mock.Object;
        }

        [Test]
        //Testing adding method by mocking both DbContext and Object
        public void InsertCart_AddItemToCart_AddedSuccessfully()
        {
            //Arrange
            Cart Item3 = new() { CartId = 3, ProductId = 100, UserId = "789"};

            //Assert             
            Assert.AreEqual((_cartRepository.AddCart(Item3)), 3);
        }


        [Test]
        public void GetCartListFromUserId_CheckAmountItems_Int()
        {
            //Arrange
            var itemsInCart = _cartRepository.GetCartItems("123"); 

            //Assert           
            Assert.AreEqual(4, itemsInCart.Count());
        }

        [Test]
        public void DeleteCartItemOnUserIdAndProductId_DeleteItem_Int()
        {
            //Arrange
            _cartRepository.DeleteCartItem(5, "456");

            //Assert           
            Assert.AreEqual(2, CartList.Count());
        }



    }
}
