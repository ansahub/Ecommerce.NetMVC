using Ecommerce.ProductApi;
using Ecommerce.ProductApi.Models;
using Ecommerce.ProductApi.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Web.Tests
{
    public class CategoryRepositoryTest
    {
        IDbContextGenerator _dbContextGenerator;
        List<Category> categoryList = new List<Category>();
        Mock<IDatabaseContext> mockDb = new Mock<IDatabaseContext>();
        ICategoryRepository _categoryRepository;

        //1. Mocking a list of Category
        Category category1 = new() { CategoryId = 1, CategoryName = "regular" };
        Category category2 = new() { CategoryId = 2, CategoryName = "merch" };
        Category category3 = new() { CategoryId = 3, CategoryName = "patterns" };

        [SetUp]
        public void Setup()
        {
            categoryList.Add(category1);
            categoryList.Add(category2);
            categoryList.Add(category3);

            //Crate context mock
            mockDb.Setup(x => x.Categories).Returns(DbContextMock.GetMockDbSet<Category>(categoryList));
            mockDb.Setup(x => x.SaveChanges()).Returns(4);

            var mock = new Mock<IDbContextGenerator>();
            mock.Setup(x => x.GenerateMyDbContext()).Returns(mockDb.Object);

            _categoryRepository = new CategoryRepository(mock.Object);

            _dbContextGenerator = mock.Object;
        }                

        [Test]
        public void GetAllCategories_CheckCategoryListAmount_Int()
        {
            //Arrange
            var categories = _categoryRepository.GetCategories();

            //Assert           
            Assert.AreEqual(3, categories.Count());
        }

        [Test]
        //Testing adding method by mocking both DbContext and Object
        public void InsertCategory_AddNewCategory_AddedSuccessfully()
        {
            //Arrange
            Category category4 = new() { CategoryId = 4, CategoryName = "sport" };

            //Assert             
            Assert.AreEqual(_categoryRepository.AddCategory(category4), 4);
        }


    }
}
