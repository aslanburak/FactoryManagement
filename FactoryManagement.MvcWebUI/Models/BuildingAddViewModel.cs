using FactoryManagement.Entities.Concrete;


namespace FactoryManagement.MvcWebUI.Models
{
    public class BuildingAddViewModel
    {
        public Building Building{ get; set; }
        public List<Factory> Factories { get; set; } = new List<Factory>();
    }
}
