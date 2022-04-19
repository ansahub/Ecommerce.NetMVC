using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ProductApi.Models;
using Serilog;

namespace ECommerce.Web.Pages
{
    public class ItemListModel : PageModel
    {
        UserManager<IdentityUser> _userManager;

        #region Properties
        [BindProperty] //Binding the property which you wanna retreive data from
        public Search Search { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<SelectListItem> Options { get; set; }
        public List<Cart> Carts { get; set; }

        #endregion Properties

        public ItemListModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<List<Product>> GetProductsFromApi()
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
            
            httpResponse = await client.GetAsync("api/cart/" + _userManager.GetUserId(HttpContext.User));

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                Carts = JsonConvert.DeserializeObject<List<Cart>>(result);
            }

            return Products;

        }

        public async Task<List<SelectListItem>> GetCategoriesFromApi()
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
                   Text = c.CategoryName
               }
               ).ToList();

            return Options;

        }

        public async Task OnGet()
        {
            await GetProductsFromApi();
            await GetCategoriesFromApi();

        }

        /// <summary>
        /// Getting the value from the Textbox and Dropdown
        /// Filter the productlist for the user accordingly
        /// </summary>
        /// <returns></returns>   
        public async Task<IActionResult> OnPostAsync()
        {
            Log.Information("Getting productlist and categorylist for filtering");
            try
            {

                var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:55237/");

                HttpResponseMessage httpResponse = await client.GetAsync("api/product");

                List<Product> FilteredList = new List<Product>();

                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = httpResponse.Content.ReadAsStringAsync().Result;
                    FilteredList = JsonConvert.DeserializeObject<List<Product>>(result);
                }

                await GetCategoriesFromApi();


                if (Search.SearchCategoryId != 0 && !String.IsNullOrEmpty(Search.SearchString))
                {
                    //Combination of Dropdown and Textbox
                    Products = FilteredList.Where(x => x.CategoryId == Search.SearchCategoryId && x.ProductName.Contains(Search.SearchString)).ToList();
                }
                else if (Search.SearchCategoryId != 0 && String.IsNullOrEmpty(Search.SearchString))
                {
                    //Dropdown with category options
                    Products = FilteredList.Where(x => x.CategoryId == Search.SearchCategoryId).ToList();
                }
                else if (!String.IsNullOrEmpty(Search.SearchString) && Search.SearchCategoryId == 0)
                {
                    //Input from Textbox
                    Products = FilteredList.Where(x => x.ProductName.Contains(Search.SearchString)).ToList();
                }
                else
                {
                    Products = FilteredList;
                }

                httpResponse = await client.GetAsync("api/cart/" + _userManager.GetUserId(HttpContext.User));

                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = httpResponse.Content.ReadAsStringAsync().Result;
                    Carts = JsonConvert.DeserializeObject<List<Cart>>(result);
                }

            }
            catch (Exception ex)
            {
                Log.Error("Error occured in ItemList.cshtml.cs.OnPostAsync()", ex.Message);
            }


            return Page();

        }
    }
}
