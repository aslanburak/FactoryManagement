using FactoryManagement.Business.Abstract;
using FactoryManagement.Entities.Concrete;

using FactoryManagement.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FactoryManagement.MvcWebUI.Controllers
{
    public class WarehouseController : Controller
    {
        private IFactoryService _factoryService;
        private IBuildingService _buildingService;
        private IWarehouseService _warehouseService;
        public WarehouseController(IFactoryService factoryService, IBuildingService buildingService, IWarehouseService warehouseService)
        {
            _factoryService = factoryService;
            _buildingService = buildingService;
            _warehouseService = warehouseService;

            
        }
        #region WAREHOUSE CONTROLLER
        public ActionResult ListWarehouse()
        {
            var model = new WarehouseListViewModel { 
            
               Warehouses= _warehouseService.GetAll()
            };
            return View(model);
        }
        //Bulding'e göre Warehouse ları listele
        public ActionResult ListWarehousesByBuilding(int buildingId)
        {
            var model = new WarehouseListViewModel
            {

                Warehouses = _warehouseService.GetByBuildingId(buildingId)
            };
            return View(model);
        }
        public ActionResult AddWarehouse()
        {
            var model = new WarehouseAddViewModel
            {
                Warehouse = new Warehouse(),
                Buildings = _buildingService.GetAll()
            };

            return View(model);

        }

        [HttpPost]
        public ActionResult AddWarehouse(Warehouse warehouse)
        {
            ModelState.Remove("warehouse.Building");
            if (ModelState.IsValid)
            {
                
                warehouse.Building = _buildingService.GetById(warehouse.BuildingID);
                _warehouseService.Add(warehouse);
            }
            return RedirectToAction("AddWarehouse");
        }

        public ActionResult UpdateWarehouse(int warehouseId)
        {
            var model = new WarehouseUpdateViewModel
            {
                Warehouse = _warehouseService.GetById(warehouseId),
                Buildings = _buildingService.GetAll()
            };
            return View(model);

        }
        [HttpPost]
        public ActionResult UpdateWarehouse(Warehouse warehouse)
        {
            ModelState.Remove("warehouse.Building");
            if (ModelState.IsValid)
            {
                _warehouseService.Update(warehouse);
            }
            return RedirectToAction("ListWarehouse");
        }

        public ActionResult DeleteWarehouse(int warehouseId)
        {
            _warehouseService.Delete(warehouseId);
            return RedirectToAction("ListWarehouse");
        }
        #endregion
    }
}
