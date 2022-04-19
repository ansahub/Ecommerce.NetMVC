using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.Models
{
    public class UserRepository
    {        
        UserManager<IdentityUser> _userManager;
        
        public UserRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<IdentityResult> CreateUser(string email, string password)
        {
            var user = new IdentityUser() { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password); //userManager creating the user

            return result;
        }

    }
}
