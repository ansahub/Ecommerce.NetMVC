using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ECommerce.Web.Pages
{
    public class CartDetailModel : PageModel
    {

        [BindProperty]
        public List<Product> Products { get; set; }
        public int TotalPrice { get; set; }

        UserManager<IdentityUser> _userManager;

        public CartDetailModel(UserManager<IdentityUser> usermanager)
        {
            _userManager = usermanager;
        }

        public async Task<List<Product>> GetProductsFromCartOnUser()
        {
            Products = new List<Product>();

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55237/");

            HttpResponseMessage httpResponse = await client.GetAsync("api/cart/" + _userManager.GetUserId(HttpContext.User));

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                Products = JsonConvert.DeserializeObject<List<Product>>(result);
            }

            foreach (var product in Products)
            {
                TotalPrice += product.ProductPrice;
            }

            return Products;
        }

        public async Task OnGet()
        {
            await GetProductsFromCartOnUser();
        }


        /// <summary>
        /// Action for Deletebutton
        /// Delete product by productId and UserId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task OnPostAsync(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55237/");

            HttpResponseMessage httpResponse = await client.DeleteAsync("api/cart/" + id + "/" + _userManager.GetUserId(HttpContext.User));

            await GetProductsFromCartOnUser();

        }      

         
        
    }
}
