using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Studio.Entities.Concrets;
using Studio.Entities.DTOs.AppUserDtos;

namespace Studio.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signManager = signManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto register)
        {
            //await _roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
            if (!ModelState.IsValid) return View();
            AppUser newUser = new()
            {
                Email = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName,
                UserName = register.UserName
            };

            var result = await _userManager.CreateAsync(newUser,register.Password);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", result.Errors.FirstOrDefault().Description);
                return View();
            }
            await _userManager.AddToRoleAsync(newUser, "Admin");
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = await _userManager.FindByNameAsync(login.UserName);
            if(user is null)
            {
                ModelState.AddModelError("", "Username or password is invalid!");
                return View();
            }
            var result=await _signManager.PasswordSignInAsync(user, login.Password, login.RememberMe, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password is invalid!");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
