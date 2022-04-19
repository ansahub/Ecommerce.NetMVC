using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Web.Pages
{
    public class RegisterPageModel : PageModel
    {
        #region private properties
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        #endregion private properties

        [BindProperty]
        public UserRegister Model { get; set; }

        /// <summary>
        /// Using IdentityUser for authentication
        /// </summary>
        /// <param name="userManager">Manage the user</param>
        /// <param name="signInManager">Manager the functionality of autentication (sign in/out)</param>
        public RegisterPageModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
       

        /// <summary>
        /// Method binding to the Register(submit) btn
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)//If the Model has everything as required
            {

                var user = new IdentityUser() { UserName = Model.Email, Email = Model.Email };
                var result = await _userManager.CreateAsync(user, Model.Password); //userManager creating the user

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false); //isPersistent = remember me
                    //signManager signs in the user
                    return RedirectToPage("LoginPage");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description); //Add all the errors in the ModelState if the createUser fails
                }

            }

            return Page();

        }
        
    }
}
