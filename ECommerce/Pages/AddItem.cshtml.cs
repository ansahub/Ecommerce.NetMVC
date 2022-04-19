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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ECommerce.Web.Pages
{
    [Authorize(Policy = "RequireAdministratorRole")]
    public class AddItemModel : PageModel
    {
        
        [BindProperty]
        public Product ProductModel { get; set; }
        
        public List<Category> Categories { get; set; }

        public List<SelectListItem> Options { get; set; }

        /// <summary>
        /// Loading the Cagetories from Database
        /// through API for the dropdown options
        /// </summary>
        /// <returns></returns>
        public async Task OnGet()
        {       
            Categories = new List<Category>();

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55237/");

            HttpResponseMessage httpResponse = await client.GetAsync("api/category");

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                Categories = JsonConvert.DeserializeObject<List<Category>>(result);
            }

            Options = Categories.Select(
                c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.CategoryName                }
                ).ToList();
        }

        /// <summary>
        /// Pressing Add Item button
        /// and creates a new Productand save it in db
        /// through API and redirect to ItemList page
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55237/");

            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    ProductId = ProductModel.ProductId,
                    ProductName = ProductModel.ProductName,
                    ProductPrice = ProductModel.ProductPrice,
                    CategoryId = ProductModel.CategoryId
                };

                var insert = await client.PostAsync("api/product", new StringContent(JsonConvert.SerializeObject(product),
                    Encoding.UTF8, "application/json"));
            }

            return RedirectToPage("ItemList");

        }
    }
}
