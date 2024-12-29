using FactoryManagement.Business.Abstract;
using FactoryManagement.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FactoryManagement.MvcWebUI.ViewComponents.Layout
{
    public class FactoryListViewComponent:ViewComponent
    {
        IFactoryService _factoryService;

        public FactoryListViewComponent(IFactoryService factoryService)
        {
            _factoryService = factoryService;
        }

        public IViewComponentResult Invoke()
        {
            var factories = _factoryService.GetAll();
            return View(factories);
        }
    }
}
