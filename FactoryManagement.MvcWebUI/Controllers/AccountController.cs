using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FactoryManagement.Entities.Concrete.CustomIdentity;
using FactoryManagement.DtoLayer.Dtos.AppUserDto;

namespace FactoryManagement.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;
        private SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public  async Task<ActionResult> Login(AppUserLoginDto appUserLoginDto)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(appUserLoginDto.Username) || string.IsNullOrEmpty(appUserLoginDto.Password))
                {
                    
                    return BadRequest("Kullanıcı adı veya şifre boş olamaz.");
                }
                var result = await _signInManager.PasswordSignInAsync(appUserLoginDto.Username, appUserLoginDto.Password, false, false);


                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                

                ModelState.AddModelError("", "Geçersiz Giriş");
            }
            return View(appUserLoginDto);

        }
        public ActionResult LogOff()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login");
        }

    }
}
