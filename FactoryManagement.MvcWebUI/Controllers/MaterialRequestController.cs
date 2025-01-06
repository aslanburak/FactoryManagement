using FactoryManagement.Business.Abstract;
using FactoryManagement.Entities.Concrete;
using FactoryManagement.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FactoryManagement.MvcWebUI.Controllers
{
    public class MaterialRequestController : Controller
    {
        IMaterialRequestService _materialRequestService;
        IMaterialTransactionService _materialTransactionService;
        IMaterialWarehouseService _materialWarehouseService;

        public MaterialRequestController(IMaterialRequestService materialRequestService, IMaterialTransactionService materialTransactionService, IMaterialWarehouseService materialWarehouseService)
        {
            _materialRequestService = materialRequestService;
            _materialTransactionService = materialTransactionService;
            _materialWarehouseService = materialWarehouseService;
        }
        [Authorize]
        public ActionResult ListRequest(string requestStatus)
        {
            if (requestStatus == null)
            {
                var model = new MaterialRequestListViewModel
                {
                    MaterialRequests = _materialRequestService.GetAll()
                };
                return View(model);
            }
            else
            {

                var model = new MaterialRequestListViewModel
                {
                    MaterialRequests = _materialRequestService.GetByRequestStatus(requestStatus)
                };

                return View(model);
            }
            
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddMaterialRequest(int quantity, int materialWarehouseId)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var materialRequest = new MaterialRequest
            {
                RequestStatus= "Pending",
                MaterialWarehouseID = materialWarehouseId,
                AppUserId = userId,
                Quantity = quantity,
                RequestTime = DateTime.Now,
            };
            _materialRequestService.Add(materialRequest);

            return RedirectToAction("ListMaterialWarehouse", "MaterialWarehouse");

        }
        [Authorize]
        public ActionResult AddRequestTransaction(int materialRequestId,string requestStatus,int materialWarehouseId,int quantity)
        {
           var materialRequest= _materialRequestService.GetById(materialRequestId);
            materialRequest.RequestStatus= requestStatus;
            materialRequest.ApprovedAt = DateTime.Now;
            _materialRequestService.Update(materialRequest);


           

            if (materialRequest.RequestStatus == "Approved")
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var materialWarehouse = _materialWarehouseService.GetById(materialWarehouseId);

                var transaction = new MaterialTransaction
                {
                    MaterialWarehouseID = materialWarehouseId,
                    AppUserId = userId,
                    Quantity = quantity,
                    TransactionType = "Eklendi",
                    TransactionDate = DateTime.Now,
                };

                materialWarehouse.StockQuantity += quantity;
                _materialWarehouseService.Update(materialWarehouse);
                _materialTransactionService.Add(transaction);

            }
            if(materialRequest.RequestStatus == "Rejected")
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var transaction = new MaterialTransaction
                {
                    MaterialWarehouseID = materialWarehouseId,
                    AppUserId = userId,
                    Quantity = quantity,
                    TransactionType = "Reddedildi",
                    TransactionDate = DateTime.Now,
                };
                _materialTransactionService.Add(transaction);
            }

            return RedirectToAction("ListRequest", "MaterialRequest");

        }
    }
}
