using Ecommerce.ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ProductApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {   
        IDbContextGenerator _dbContextGenerator;
        IDatabaseContext _databaseContext;

        public CategoryRepository(IDbContextGenerator contextGenerator)
        {
            _dbContextGenerator = contextGenerator;
            _databaseContext = _dbContextGenerator.GenerateMyDbContext();
        }
                

        public List<Category> GetCategories()
        {
            var result = _databaseContext.Categories.ToList();
            return result;
        }

        public int AddCategory(Category category)
        {          
            _databaseContext.Categories.Add(category);

            return _databaseContext.SaveChanges();           
            
        }
    }
}
