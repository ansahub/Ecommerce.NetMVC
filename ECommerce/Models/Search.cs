using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.Models
{
    public class Search
    {
        [BindProperty]
        public int SearchCategoryId { get; set; }
        public string SearchString { get; set; }
    }
}
