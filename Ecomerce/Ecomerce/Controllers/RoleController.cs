using Ecomerce.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Controllers
{
  
   
    [Authorize(Roles = "Owner")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel newRole)
        {
            if(ModelState.IsValid)
            {

                IdentityRole role = new IdentityRole();
                role.Name = newRole.RoleName;

               IdentityResult result= await roleManager.CreateAsync(role);
                if(result.Succeeded)
                {
                    return View();
                }
                else {

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
          
            return View(newRole);
        }


        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }
      


    }
}
