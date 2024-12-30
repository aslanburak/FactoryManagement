using FactoryManagement.Entities.Concrete.CustomIdentity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FactoryManagement.MvcWebUI.ViewComponents.Layout
{
    public class ProfilLayoutViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfilLayoutViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var model = new AppUser
            {
                Name = values.Name,
                Surname= values.Surname,
                Email= values.Email, 

               
            };


            return View(model);
        }
    }

}
