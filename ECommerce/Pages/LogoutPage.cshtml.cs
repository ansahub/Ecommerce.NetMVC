using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Web.Pages
{
    public class LogoutPageModel : PageModel
    {
        SignInManager<IdentityUser> _signInManager;

        public LogoutPageModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        

        /// <summary>
        /// After logged out return to the Login page
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage("LoginPage");
        }

        /// <summary>
        /// If not logging out return to the Home Page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPostDontLogoutAsync()
        {
            return RedirectToPage("Index");
        }

    }
}
