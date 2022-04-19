using Ecommerce.ProductApi.Models;
using Ecommerce.ProductApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ProductApi.Repositories
{

    /// <summary>
    /// Using DbContext by creating object of IDbContextGenerator
    /// </summary>
    public class ProductRepository : IProductRepository
    {

        IDbContextGenerator _dbContextGenerator;
        IDatabaseContext _databaseContext;

        public ProductRepository(IDbContextGenerator contextGenerator)
        {
            _dbContextGenerator = contextGenerator;
            _databaseContext = _dbContextGenerator.GenerateMyDbContext();
        }

        public virtual int AddProduct(Product product)
        {
            _databaseContext.Products.Add(product);

            return _databaseContext.SaveChanges();
        }
        

        public List<Product> GetProducts()
        {            
            var result = _databaseContext.Products.ToList();
            return result;
        }

        public Product GetProductById(int id)
        {
            //Getting data from DatabaseGenerator which also creates databaseContext
            var result = (from x in _databaseContext.Products where x.ProductId == id select x)
                .ToList().FirstOrDefault();
            return result;
        }


    }
}
