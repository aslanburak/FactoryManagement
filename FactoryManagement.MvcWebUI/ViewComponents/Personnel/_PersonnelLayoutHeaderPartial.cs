using Microsoft.AspNetCore.Mvc;

namespace FactoryManagement.MvcWebUI.ViewComponents.Personnel
{
    public class _PersonnelLayoutHeaderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
