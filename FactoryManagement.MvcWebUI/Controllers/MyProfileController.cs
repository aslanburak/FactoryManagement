using Microsoft.AspNetCore.Mvc;

namespace FactoryManagement.MvcWebUI.Controllers
{
    public class MyProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
