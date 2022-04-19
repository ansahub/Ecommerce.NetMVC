using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ProductApi.Models;

namespace ECommerce.Web.Pages
{
    public class FinalPageModel : PageModel
    {
        UserManager<IdentityUser> _userManager;
        public List<Cart> Carts { get; set; }


        public FinalPageModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// When the page loads (after pressing Checkout btn in CartDetail page)
        /// the method calls the API and get the items from the user, add to the order tabla
        /// and finally deletes all the items in the Cart table
        /// </summary>
        /// <returns></returns>
        public async Task OnGet()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55237/");

            Order order = new Order() { UserId = _userManager.GetUserId(HttpContext.User) };
                        
            HttpResponseMessage httpResponse = await client.PostAsync("api/order/",
                new StringContent(JsonConvert.SerializeObject(order),
                    Encoding.UTF8, "application/json"));            

            httpResponse = await client.DeleteAsync("api/cart/" +  _userManager.GetUserId(HttpContext.User));

        }
    }
}
