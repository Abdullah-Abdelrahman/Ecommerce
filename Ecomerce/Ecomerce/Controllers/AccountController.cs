using Ecomerce.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> _userManager,SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        [HttpGet]
        public  IActionResult Registeration()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registeration(RegisterAccountViewModel newAcount)
        {
            if(ModelState.IsValid==true)
            {
                IdentityUser user= new IdentityUser();
                user.Email = newAcount.Email;
                user.UserName = newAcount.UserName;
              
                IdentityResult result=   await userManager.CreateAsync(user,newAcount.Password);
                if(result.Succeeded)
                {
                   await signInManager.SignInAsync(user, false);
                    await userManager.AddToRoleAsync(user, "User");
                    return View("UserPage");
                }
                
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                
            }
            return View(newAcount);
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl = "~/Home/index")
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login,string ReturnUrl="~/Home/index")
        {
            if(ModelState.IsValid==true)
            {
                IdentityUser user = await userManager.FindByNameAsync(login.userName);
                if(user == null)
                {
                    ModelState.AddModelError("", "Unmateched User Name & Pasword");
                    return View(login);
                }
                Microsoft.AspNetCore.Identity.SignInResult signInResult = await signInManager.PasswordSignInAsync(user, login.password,login.isPersisite,false);

                if(signInResult.Succeeded)
                {
                    return LocalRedirect(ReturnUrl);
                }
            }
            ModelState.AddModelError("", "Unmateched User Name & Pasword");
            return View(login);
        }

        [HttpGet]
        public IActionResult OpenAccount()
        {

            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Owner"))
                {
                    return View("OwnerPage");

                }
                else if (User.IsInRole("Admin"))
                {
                    return View("OwnerPage");
                }
                else if(User.IsInRole("User"))
                {
                    return View("UserPage");
                }
               
            }
          
                return RedirectToAction("Login", "Account");


            



        }
        [HttpGet]
		public IActionResult UserPage()
		{
			
			return View();
		}
        [HttpGet]
        public IActionResult AdminPage()
        {

            return View();
        }
        [HttpGet]
        public IActionResult OwnerPage()
        {

            return View();
        }



        [HttpGet]
        public IActionResult AdminRegisteration()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdminRegisteration(RegisterAccountViewModel newAcount)
        {
            if (ModelState.IsValid == true)
            {
                IdentityUser user = new IdentityUser();
                user.Email = newAcount.Email;
                user.UserName = newAcount.UserName;

                IdentityResult result = await userManager.CreateAsync(user, newAcount.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    await userManager.AddToRoleAsync(user, "Admin");

                    return RedirectToAction("HR", "Admin");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(newAcount);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
