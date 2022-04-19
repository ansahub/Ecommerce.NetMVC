using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.Models
{
    public class UserRegister
    {
        [Key]        
        public int UserId { get; set; }

        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Compare(nameof(Password), ErrorMessage = "Password didn't match")]
        public string ConfirmPassword { get; set; }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
