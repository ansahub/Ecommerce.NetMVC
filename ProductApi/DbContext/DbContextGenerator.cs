using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ProductApi
{
    /// <summary>
    /// Wrapper class
    /// The purpose is to be able to mock DbContext for testing
    /// and not using Dbcontext directly
    /// Getting connectionString and creating one database object. 
    /// Here we are using AppSetting.cs and the structure 
    /// should match ConnectionString section in appsettings.json
    /// </summary>
    public class DbContextGenerator : IDbContextGenerator
    {
        readonly IOptions<AppSetting> _options;                 
        string _connectionString;

        public DbContextGenerator(IOptions<AppSetting> options)
        {
            _options = options;
        }

        /// <summary>     
        /// Creating new DatabaseContext       
        /// </summary>
        /// <returns>one dbContext object</returns>
        public IDatabaseContext GenerateMyDbContext()
        {
            Log.Information("Generating DbContext with connectionstring");
            try
            {
                _connectionString = _options.Value.ConnectionString;
                
            }
            catch (Exception ex)
            {
                Log.Error("The error occured in DbContextGenerator.GenerateMyDbContext()", ex.Message);
            }

            return new DatabaseContext(_connectionString);
        }

        
    }
}
