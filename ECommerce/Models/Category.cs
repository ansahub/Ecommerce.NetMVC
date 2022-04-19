using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.Models
{
   
    public class Category
    {        
        public int CategoryId { get; set; }        
        public string CategoryName { get; set; }

    }
}
