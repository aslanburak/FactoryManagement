using FactoryManagement.Entities.Concrete;

namespace FactoryManagement.MvcWebUI.Models
{
    public class MaterialWarehouseAddViewModel
    {
        public MaterialWarehouse MaterialWarehouse { get; set; }
        public List<Warehouse> Warehouses { get; set; }
        public List<Material> Materials { get; set; }

    }
}
