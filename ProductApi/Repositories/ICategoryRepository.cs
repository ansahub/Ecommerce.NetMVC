using Ecommerce.ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ProductApi.Repositories { 
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        int AddCategory(Category category);
    }
}
