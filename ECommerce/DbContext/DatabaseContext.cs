using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web
{
    /// <summary>
    /// Using IdentityDbContext
    /// connecting authentication part to the database
    /// which creates all the table (e.g User roles) in the db 
    /// </summary>
    public class DatabaseContext : IdentityDbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> connectionStr) : base(connectionStr)
        {

        }


        public override int SaveChanges()
        {
            return base.SaveChanges();
        }



    }

}