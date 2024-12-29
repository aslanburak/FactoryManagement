using FactoryManagement.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using FactoryManagement.Entities.Concrete;
using FactoryManagement.Entities.Concrete.CustomIdentity;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using FactoryManagement.MvcWebUI.Models;

namespace FactoryManagement.MvcWebUI.Controllers
{
    public class MaterialTransactionController : Controller
    {
        IMaterialTransactionService _materialTransactionService;
        IMaterialWarehouseService _materialWarehouseService;
        private readonly UserManager<AppUser> _userManager;

        public MaterialTransactionController(IMaterialTransactionService materialTransactionService, IMaterialWarehouseService materialWarehouseService, UserManager<AppUser> userManager)
        {
            _materialTransactionService = materialTransactionService;
            _materialWarehouseService = materialWarehouseService;
            _userManager = userManager;
        }

        public ActionResult ListTransactions()
        {
            var model = new TransactionListViewModel
            {
               MaterialTransactions= _materialTransactionService.GetAll()
            };
            return View(model);
        }

       

        [HttpPost]
        public async Task<IActionResult> AddTransaction(int quantity, int warehouseId, string transactionType, int materialWarehouseId,int materialId)
        {

            // Login olan kullanıcının ID'sini al
            var userId =int.Parse( User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userIdstring = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var appUser = await _userManager.FindByIdAsync(userIdstring);
            var roles = await _userManager.GetRolesAsync(appUser);
            var role =roles.FirstOrDefault();


            var transaction = new MaterialTransaction
            {
                MaterialWarehouseID = materialWarehouseId,
                AppUserId=userId,
                Quantity = quantity,
                TransactionType = transactionType,
                TransactionDate= DateTime.Now,
            };

            var materialWarehouse= _materialWarehouseService.GetById(materialWarehouseId);
            if(transactionType=="Eklendi"&& quantity > 0)
            {
                materialWarehouse.StockQuantity += quantity;
                _materialWarehouseService.Update(materialWarehouse);
                _materialTransactionService.Add(transaction);
            }

            if (transactionType == "Çıkarıldı"){

                var currentStock = materialWarehouse.StockQuantity -= quantity;
                if (currentStock >= 0) {
                    _materialWarehouseService.Update(materialWarehouse);
                    _materialTransactionService.Add(transaction);
                }
            }
            if (transactionType == "Talep")
            {
                _materialTransactionService.Add(transaction);
            }





                return RedirectToAction("GetMaterialsByWarehouseId", "MaterialWarehouse", new { warehouseId= warehouseId });
        }

    }
}
