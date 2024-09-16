using Doggie.Context;
using Doggie.Dtos;
using Doggie.Extensions;
using Doggie.Modelsss;
using Doggie.Modelsss.BaseMode;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace Doggie.Controllers
{
	public class AccountController : Controller
	{
        private readonly DoggieFriend _doggieContext;
		private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(DoggieFriend doggiecontext, UserManager<AppUser> userManager,  SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _doggieContext = doggiecontext;
			_userManager= userManager;
            _signInManager= signInManager;        
            _roleManager= roleManager;  

        }

        [HttpGet]
		public async Task<IActionResult> Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel regsiterViewModel)
		{
			////if (!ModelState.IsValid)
			////{
			////    return View();
			////}

			AppUser appUser = new AppUser
			{
				Email = regsiterViewModel.Email,
				UserName = regsiterViewModel.UserName,

			};
			

			IdentityResult identityResult = await _userManager.CreateAsync(appUser,regsiterViewModel.Password);

			if (!identityResult.Succeeded)
			{
				foreach (var item in identityResult.Errors)
				{
					ModelState.AddModelError("", item.Description);
				}
				return View(regsiterViewModel);

			}
			await _userManager.AddToRoleAsync(appUser, "User");

            return RedirectToAction("Index", "Home");


        }
		[HttpGet]
		public  IActionResult Login()
		{
            return View();
        }

		[HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {

			//if (!ModelState.IsValid)
			//{
			//    return View(loginViewModel);
			//}
			AppUser appUser = await _userManager.FindByNameAsync(loginViewModel.UserName);
            if (appUser == null)
            {
                ModelState.AddModelError("", "UserName or Paswword is inCorrect");
                return View(loginViewModel);
            }
            var result = await _signInManager.PasswordSignInAsync(appUser, loginViewModel.Password, loginViewModel.IsRememberMe, true);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "Your account is blocked for 5 minutes");
                    return View(loginViewModel);
                }
                ModelState.AddModelError("", "UserName or Paswword is inCorrect");
                return View(loginViewModel);
            }
            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");


        }




    }
}
