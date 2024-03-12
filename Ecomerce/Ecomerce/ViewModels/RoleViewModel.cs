using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ecomerce.ViewModels
{
    [Keyless]
    public class RoleViewModel
    {
        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
