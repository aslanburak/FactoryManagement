using FactoryManagement.Entities.Concrete;

namespace FactoryManagement.MvcWebUI.Models
{
    public class BuildingUpdateViewModel
    {
        public Building  Building { get; set; }
        public List<Factory> Factories { get; set; }
    }
}
