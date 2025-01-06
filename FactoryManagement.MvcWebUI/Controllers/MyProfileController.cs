using FactoryManagement.DtoLayer.Dtos.AppUserDto;
using FactoryManagement.Entities.Concrete.CustomIdentity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FactoryManagement.MvcWebUI.Controllers
{
    public class MyProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MyProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            var model = new AppUserEditDto
            {
                Name=values.Name,
                Surname=values.Surname,
                Email=values.Email,
                Username=values.UserName,
                Password=values.PasswordHash

            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditDto appUserEditDto) 
        {
            if (appUserEditDto.Password == appUserEditDto.ConfirmPassword) 
            { 
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = appUserEditDto.Name;    
                user.Surname = appUserEditDto.Surname;
                user.Email = appUserEditDto.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDto.Password);
                var result= await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                   return RedirectToAction("LogOff", "Account");
                }

            }
            return View();
        }
        

    }
}
