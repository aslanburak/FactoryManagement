using AutoMapper;
using FactoryManagement.Business.Abstract;
using FactoryManagement.Entities.Concrete;
using FactoryManagement.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FactoryManagement.MvcWebUI.Controllers
{
    public class FactoryController : Controller
    {
        private IFactoryService _factoryService;
        private IBuildingService _buildingService;
        private IWarehouseService _warehouseService;
        public FactoryController(IFactoryService factoryService, IBuildingService buildingService, IWarehouseService warehouseService)
        {
            _factoryService = factoryService;
            _buildingService = buildingService;
            _warehouseService = warehouseService;
            
        }
        #region FACTORY CONTROLLER
        [Authorize(Policy = "RequireAdminOrPersonnel")]
        public ActionResult ListFactory()
        {
            var model = new FactoryListViewModel
            {
                Factories = _factoryService.GetAll()
            };
            ViewData["factories"] = _factoryService.GetAll();

            return View(model);
        }
        [Authorize(Roles ="Admin")]
        public ActionResult AddFactory()
        {

            var model = new FactoryAddViewModel
            {
                Factory = new Factory()  //modele boş bir Factory nesnesi yolladık
            };
            return View(model);

        }

        [HttpPost]
        public ActionResult AddFactory(Factory factory)
        {
            if (ModelState.IsValid)
            {

                _factoryService.Add(factory);

            }

            return RedirectToAction("AddBuilding","Building");

        }
        [Authorize(Roles ="Admin")]
        public ActionResult UpdateFactory(int factoryId)
        {
            var model = new FactoryUpdateViewModel
            {

                Factory = _factoryService.GetById(factoryId)

            };
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateFactory(Factory factory)
        {
            if (ModelState.IsValid)
            {
                _factoryService.Update(factory);
            }

            return RedirectToAction("ListFactory");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteFactory(int factoryId)
        {
            _factoryService.Delete(factoryId);
            return RedirectToAction("ListFactory");
        }
        #endregion
    }
}
