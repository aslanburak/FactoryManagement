using FactoryManagement.Business.Abstract;
using FactoryManagement.Entities.Concrete;
using FactoryManagement.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FactoryManagement.MvcWebUI.Controllers
{
    public class BuildingController : Controller
    {
        private IFactoryService _factoryService;
        private IBuildingService _buildingService;
        private IWarehouseService _warehouseService;
        public BuildingController(IFactoryService factoryService, IBuildingService buildingService, IWarehouseService warehouseService)
        {
            _factoryService = factoryService;
            _buildingService = buildingService;
            _warehouseService = warehouseService;
            
        }
        #region BUİLDİNG CONTROLLER
        public ActionResult AddBuilding()
        {

            var model = new BuildingAddViewModel
            {
                Building = new Building(),

                Factories = _factoryService.GetAll()

            };

            return View(model);

        }
        [HttpPost]
        public ActionResult AddBuilding(Building Building)
        {
            ModelState.Remove("Building.Factory");


            if (ModelState.IsValid)
            {

                _buildingService.Add(Building);

            }

            return RedirectToAction("AddBuilding");
        }
        public ActionResult BuildingsByFactory(int factoryId = 0)
        {
            if (factoryId == 0)
            {
                var buildings = _buildingService.GetAll();
                return View(buildings);
            }
            else
            {
                var buildings = _buildingService.GetByFactoryId(factoryId);
                return View(buildings);
            }


        }


        public ActionResult UpdateBuilding(int buildingId)
        {
            var model = new BuildingUpdateViewModel
            {
                Building = _buildingService.GetById(buildingId),
                Factories = _factoryService.GetAll()
            };
            return View(model);

        }
        [HttpPost]
        public ActionResult UpdateBuilding(Building building)
        {
            ModelState.Remove("Building.Factory");
            if (ModelState.IsValid)
            {

                _buildingService.Update(building);
            }
            return RedirectToAction("BuildingsByFactory", new { factoryId = building.FactoryID });
        }
        public ActionResult DeleteBuilding(int buildingId)
        {
            _buildingService.Delete(buildingId);
            return RedirectToAction("BuildingsByFactory");
        }

        #endregion
    }
}
