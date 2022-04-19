using Ecommerce.ProductApi;
using Ecommerce.ProductApi.Models;
using Ecommerce.ProductApi.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Web.Tests
{
    /// <summary> 
    /// Testing methods from ProductRepository class
    /// Mocking the data to test - using "Moq"
    /// </summary>
    public class ProductRepositoryTest
    {                
        IDbContextGenerator _dbContextGenerator;
        IProductRepository _productRepository;
        List<Product> productList = new List<Product>();
        Mock<IDatabaseContext> mockDb = new Mock<IDatabaseContext>();

        //1. Mocking a list of Product
        Product regular = new() { ProductId = 1, ProductName = "Basic White", ProductPrice = 129, CategoryId = 1 };
        Product merch = new() { ProductId = 2, ProductName = "Super Mario", ProductPrice = 349, CategoryId = 2};
        Product patterns = new() { ProductId = 3, ProductName = "Flowers", ProductPrice = 199, CategoryId = 3 };

        [SetUp]
        public void Setup()
        {                              
            productList.Add(regular);productList.Add(merch);
            productList.Add(patterns);
            
            //Crate context mock
            mockDb.Setup(x => x.Products).Returns(DbContextMock.GetMockDbSet<Product>(productList));
            mockDb.Setup(x => x.SaveChanges()).Returns(4);

            var mock = new Mock<IDbContextGenerator>();
            mock.Setup(x => x.GenerateMyDbContext()).Returns(mockDb.Object);

            _productRepository = new ProductRepository(mock.Object);

            _dbContextGenerator = mock.Object;
        }      


        [Test]
        public void GetAllProducts_CheckCategoryListAmount_Int()
        {
            //Arrange
            var products = _productRepository.GetProducts();

            //Assert           
            Assert.AreEqual(3, products.Count());
        }

        [Test]        
        public void GetProductById_ProductAvailable_Product()
        {
            //Arrange
            var product = _productRepository.GetProductById(2);

            //Assert           
            Assert.AreEqual(merch, product);      
        }

       
    }
}