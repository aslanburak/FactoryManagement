using FactoryManagement.DtoLayer.Dtos.AppUserDto;
using FactoryManagement.Entities.Concrete.CustomIdentity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FactoryManagement.MvcWebUI.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;
        private SignInManager<AppUser> _signInManager;

        public AdminController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        [Authorize(Roles="Admin")]
        public ActionResult AdminRegister()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<ActionResult> AdminRegister(AppUserRegisterDto appUserRegisterDto)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    UserName = appUserRegisterDto.Username,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,

                };
                IdentityResult result =  _userManager.CreateAsync(appUser, appUserRegisterDto.Password).Result;
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("Admin").Result)
                    {
                        AppRole adminRole = new AppRole
                        {
                            Name = "Admin"

                        };

                        IdentityResult adminRoleResult = _roleManager.CreateAsync(adminRole).Result;


                        if (!adminRoleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "Admin rolünü ekleyemiyoruz!");
                            return View(appUserRegisterDto);
                        }
                    }
                    _userManager.AddToRoleAsync(appUser, "Admin").Wait();

                    return RedirectToAction("Login", "Account");
                }



            }
            return View(appUserRegisterDto);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult PersonnelRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> PersonnelRegister(AppUserRegisterDto appUserRegisterDto)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    UserName = appUserRegisterDto.Username,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,

                };
                IdentityResult result = _userManager.CreateAsync(appUser, appUserRegisterDto.Password).Result;
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("Personnel").Result)
                    {
                        AppRole personnelRole = new AppRole
                        {
                            Name = "Personnel"
                        };

                        IdentityResult personnelRoleResult = _roleManager.CreateAsync(personnelRole).Result;

                        if (!personnelRoleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "Personel rolünü ekleyemiyoruz!");
                            return View(appUserRegisterDto);
                        }
                    }

                        _userManager.AddToRoleAsync(appUser, "Personnel").Wait();
                        return RedirectToAction("Login", "Account");
                }



            }
            return View(appUserRegisterDto);
        }

    }
}
