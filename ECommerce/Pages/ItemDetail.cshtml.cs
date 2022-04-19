using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ProductApi.Models;
namespace ECommerce.Web.Pages
{
    public class ItemDetailModel : PageModel
    {
        [BindProperty] //Binding the property which you wanna retreive data from
        public Product Item { get; set; }
        public Category Category { get; set; }
        public Cart Cart { get; set; }

        UserManager<IdentityUser> _userManager;

        public ItemDetailModel(UserManager<IdentityUser> usermanager)
        {
            _userManager = usermanager;
        }

        /// <summary>
        /// When loading the page 
        /// (after pressing the View detail btn in ItemList page)
        /// the method makes the call to API with productId to 
        /// get the chosen Product and also get the CategoryId
        /// related to the Product. 
        /// The product detail displays on the page
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns></returns>
        public async Task OnGet(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55237/");

            HttpResponseMessage httpResponse = await client.GetAsync("api/product/" + id);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                Item = JsonConvert.DeserializeObject<Product>(result);
            }

            List<Category> Categories = new List<Category>();
            httpResponse = await client.GetAsync("api/category");

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                Categories = JsonConvert.DeserializeObject<List<Category>>(result);
            }

            Category = Categories.Where(x => x.CategoryId == Item.CategoryId).FirstOrDefault();
        }

        /// <summary>
        /// When press the Cart button
        /// the method creates a new Cart with ProductId & UserId
        /// and redirecting to the ItemList page
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55237/");

            if (ModelState.IsValid)
            {
                Cart cart = new Cart
                {
                    ProductId = Item.ProductId,
                    UserId = _userManager.GetUserId(HttpContext.User)
                };

                var insert = await client.PostAsync("api/cart", new StringContent(JsonConvert.SerializeObject(cart),
                    Encoding.UTF8, "application/json"));
            }

            return RedirectToPage("ItemList");

        }
    }
}
