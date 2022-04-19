using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ECommerce.Web.Pages
{
    [Authorize(Policy = "RequireAdministratorRole")]
    public class AddCategoryModel : PageModel
    {
        [BindProperty]
        public Category Model { get; set; }
       
        /// <summary>
        /// When clicking on Add Category button
        /// Creating a new Category and save it in database
        /// through Api and redirect to the CategoryList page
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55237/");

            Category category = new Category { CategoryId = Model.CategoryId, CategoryName = Model.CategoryName };

            var insert = await client.PostAsync("api/category", new StringContent(JsonConvert.SerializeObject(category), 
                Encoding.UTF8, "application/json"));


            return RedirectToPage("CategoryList"); //CategoryList is the page name

        }


    }
}
