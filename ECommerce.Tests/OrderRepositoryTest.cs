using Ecommerce.ProductApi;
using Ecommerce.ProductApi.Models;
using Ecommerce.ProductApi.Repositories;
using Moq;
using NUnit.Framework;
using ProductApi.Models;
using ProductApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Web.Tests
{
    public class OrderRepositoryTest
    {
        IDbContextGenerator _dbContextGenerator;
        IOrderRepository _orderRepository;
        ICartRepository _cartRepository;

        List<Order> OrderList = new List<Order>();
        List<Cart> CartList = new List<Cart>();
        List<Product> ProductList = new List<Product>();
        Mock<IDatabaseContext> mockDb = new Mock<IDatabaseContext>();


        //1. Mocking a list of Order
        Order Order1 = new() { OrderId = 1, ProductId = 1, UserId = "123", };
        Order Order2 = new() { OrderId = 2, ProductId = 5, UserId = "456", };

        //2. Mocking a list of Cart
        Cart Item1 = new() { CartId = 1, ProductId = 1, UserId = "123", };
        Cart Item2 = new() { CartId = 2, ProductId = 5, UserId = "456", };

        //3. Mocking a list of Product
        Product Product1 = new() { ProductId = 1, ProductName = "Basic White", ProductPrice = 129, CategoryId = 1 };
        Product Product2 = new() { ProductId = 5, ProductName = "Flowers", ProductPrice = 199, CategoryId = 3 };


        [SetUp]
        public void Setup()
        {
            OrderList.Add(Order1);
            OrderList.Add(Order2);

            CartList.Add(Item1);
            CartList.Add(Item2);

            ProductList.Add(Product1);
            ProductList.Add(Product2);

            //Create context mock
            mockDb.Setup(x => x.Orders).Returns(DbContextMock.GetMockDbSet<Order>(OrderList));
            mockDb.Setup(x => x.Carts).Returns(DbContextMock.GetMockDbSet<Cart>(CartList));
            mockDb.Setup(x => x.Products).Returns(DbContextMock.GetMockDbSet<Product>(ProductList));
            mockDb.Setup(x => x.SaveChanges()).Returns(2);

            var mock = new Mock<IDbContextGenerator>();
            mock.Setup(x => x.GenerateMyDbContext()).Returns(mockDb.Object);

            _cartRepository = new CartRepository(mock.Object);
            _orderRepository = new OrderRepository(mock.Object, _cartRepository);

            _dbContextGenerator = mock.Object;
        }

        [Test]
        //Testing adding method by mocking both DbContext and Object
        public void InsertOrder_AddOrder_AddedSuccessfully()
        {
            //Assert             
            Assert.AreEqual((_orderRepository.AddOrderFromCart("789")), 2);
        }


    }
}
