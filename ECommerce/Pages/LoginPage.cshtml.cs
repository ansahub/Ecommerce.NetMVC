using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace ECommerce.Web.Pages
{
    public class LoginPageModel : PageModel
    {
        SignInManager<IdentityUser> _signInManager;

        [BindProperty]
        public Login Model { get; set; }

        public LoginPageModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;

        }

        /// <summary>
        /// Method binding to the "Sign In button"
        /// Create log and log error/info using 'Serilog'
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            Log.Information("Logging in with email and password");
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(Model.Email, Model.Password, false, false);

                    if (result.Succeeded)
                    {
                        if (returnUrl == null || returnUrl == "/")
                        {
                            return RedirectToPage("ItemList");
                        }
                        else
                        {
                            return RedirectToPage(returnUrl);
                        }                       
                    }
                    else
                    {
                        //Add the error to ModelState and display message if login fails
                        ModelState.AddModelError("", "User name or password is incorrect");
                    }

                }
            }
            catch (Exception ex)
            {
                //Log the error
                Log.Error("The error occured in LoginPage.cshtml.se.OnPostAsync()", ex.Message);
            }

            return Page();

        }




    }
}



