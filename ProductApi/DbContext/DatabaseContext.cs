using Ecommerce.ProductApi.Models;
using Microsoft.EntityFrameworkCore;
using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ProductApi
{
    /// <summary>
    /// Required to setup to the database
    /// Look at methods such as Configuring, UseSqlServer etc.
    //// With DbSet<Product> you're mapping with your db table
    /// </summary>
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        string _connectionString;

        public DatabaseContext(string connectionStr) : base()
        {
            _connectionString = connectionStr;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

    }
}
