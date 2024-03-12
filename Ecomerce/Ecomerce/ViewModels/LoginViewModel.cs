using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ecomerce.ViewModels
{
    [Keyless]
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="User Name")]
        public string userName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name ="Remember Me")]
        public bool isPersisite { get; set; }
    }
}
