using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace ECommerce.Web.Pages
{
    public class ProductListModel : PageModel
    {
        public List<Product> Products { get; set; }


        public async Task OnGet()
        {
            Products = new List<Product>();

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55237/");

            HttpResponseMessage httpResponse = await client.GetAsync("api/product");

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                Products = JsonConvert.DeserializeObject<List<Product>>(result);
            }
        }
    }
}
