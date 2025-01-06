using Microsoft.AspNetCore.Mvc;
using FactoryManagement.Business.Abstract;
using FactoryManagement.MvcWebUI.Models;
using FactoryManagement.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace FactoryManagement.MvcWebUI.Controllers
{
    public class MaterialController : Controller
    {
        IMaterialService _materialService;
        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
            
        }
        [Authorize]
        public ActionResult ListMaterial()
        {
            var model = new MaterialListViewModel
            {
                Materials = _materialService.GetAll()
            };
            return View(model);

        }
        [Authorize]
        public ActionResult AddMaterial()
        {
            var model = new MaterialAddViewModel
            {
               Material = new Material()
            };
            return View(model); 
            
        }

        [HttpPost]
        public ActionResult AddMaterial(Material material)
        {
            if (ModelState.IsValid)
            {
                _materialService.Add(material);
            }
            return RedirectToAction("ListMaterial");

        }
    }
}
