using Microsoft.EntityFrameworkCore;
using Moq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Web.Tests
{
    public class DbContextMock
    {
        public static DbSet<T> GetMockDbSet<T>(List<T> productList) where T : class //T should be class only
        {
            var dbSet = new Mock<DbSet<T>>();

            try
            {
                var result = productList.AsQueryable();

                dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(result.Provider);
                dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(result.Expression);
                dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(result.ElementType);
                dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => result.GetEnumerator());

                dbSet.Setup(x => x.Add(It.IsAny<T>())).Callback<T>(y => productList.Add(y));

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

            return dbSet.Object;

        }
    }



}
