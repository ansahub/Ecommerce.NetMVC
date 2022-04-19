using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ECommerce.Web.Pages
{
    [Authorize(Policy = "RequireAdministratorRole")]
    public class CategoryListModel : PageModel
    {        
        public List<Category> Categories { get; set; }

        /// <summary>
        /// Load, and get alla the cagetories from DB
        /// through API
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

        }
    }
}
