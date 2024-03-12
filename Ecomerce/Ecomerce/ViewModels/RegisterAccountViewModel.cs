using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ecomerce.ViewModels
{
    [Keyless]
    public class RegisterAccountViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password",ErrorMessage ="Not Matched")]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
