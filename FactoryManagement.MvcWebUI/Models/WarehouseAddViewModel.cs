using FactoryManagement.Entities.Concrete;


namespace FactoryManagement.MvcWebUI.Models
{
    public class WarehouseAddViewModel
    {
        public Warehouse Warehouse { get; set; }
        public List<Building> Buildings { get; set; }
    }
}
