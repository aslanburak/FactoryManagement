using FactoryManagement.Business.Abstract;
using FactoryManagement.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using FactoryManagement.MvcWebUI.Models;
using FactoryManagement.Entities.Concrete.CustomIdentity;
using System.Security.Claims;
namespace FactoryManagement.MvcWebUI.Controllers
{
    public class MaterialWarehouseController : Controller
    {
       private IMaterialWarehouseService _materialWarehouseService;
       private IMaterialService _materialService;
        private IWarehouseService _warehouseService;
        private IMaterialTransactionService _materialTransactionService;

        public MaterialWarehouseController(IMaterialWarehouseService materialWarehouseService, IMaterialService materialService, IWarehouseService warehouseService, IMaterialTransactionService materialTransactionService)
        {
            _materialWarehouseService = materialWarehouseService;
            _materialService = materialService;
            _warehouseService = warehouseService;
            _materialTransactionService = materialTransactionService;
        }

        public ActionResult ListMaterialWarehouse(int warehouseId = 0, string materialName = "" ,int materialId=0)
        {
          
            var model = new MaterialWarehouseListViewModel();

            
            if (warehouseId == 0)
            {
                model.MaterialWarehouses = _materialWarehouseService.GetAll();
            }
            else
            {
                model.MaterialWarehouses = _materialWarehouseService.GetByWarehouseId(warehouseId);
            }
            if (materialId != 0)
            {
                model.MaterialWarehouses = model.MaterialWarehouses
                    .Where(mw => mw.Material.MaterialID == materialId)
                    .ToList();
            }


            if (!string.IsNullOrEmpty(materialName))
            {
                model.MaterialWarehouses = model.MaterialWarehouses
                    .Where(mw => mw.Material.Name.Contains(materialName, StringComparison.OrdinalIgnoreCase))
                    .ToList(); 
            }

            return View(model);
        }

        //DepoID ile bu depoda hangi ürünlerin olduğunu göreceğiz

        public ActionResult GetMaterialsByWarehouseId(int warehouseId)
        {
            var model = new MaterialsByWarehouseListViewModel
            {
                MaterialWarehouses = _materialWarehouseService.GetByWarehouseId(warehouseId)
            };
            return View(model);
        }

        //materialId ye göre depoları getir
        public ActionResult GetMaterialWarehousesByMaterialId(int materialId)
        {
           var MaterialWarehouses= _materialWarehouseService.GetByMaterialId(materialId);
            return View(MaterialWarehouses);
        }
        public ActionResult AddMaterialWarehouse()
        {
            var model = new MaterialWarehouseAddViewModel
            {
                MaterialWarehouse = new MaterialWarehouse(),
                Warehouses = _warehouseService.GetAll(),
                Materials =_materialService.GetAll(),
            };


            return View(model);
        }
        [HttpPost]
        public ActionResult AddMaterialWarehouse(MaterialWarehouse materialWarehouse)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            ModelState.Remove("materialWarehouse.Warehouse");
            ModelState.Remove("materialWarehouse.Material");
            if (ModelState.IsValid) 
            { 
            
                _materialWarehouseService.Add(materialWarehouse);
            }

            var trasnaction = new MaterialTransaction
            {

                MaterialWarehouseID = materialWarehouse.MaterialWarehouseID,
                AppUserId = userId,
                Quantity = materialWarehouse.StockQuantity,
                TransactionType = "Depoya Eklendi",
                TransactionDate = DateTime.Now,
            };
            _materialTransactionService.Add(trasnaction);

            return RedirectToAction("AddMaterialWarehouse");
        }
    }
}
