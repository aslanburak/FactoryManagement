using FactoryManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Entities.Concrete
{
    public class Warehouse:IEntity
    {
        public int WarehouseID { get; set; }
        public int BuildingID { get; set; }
        public string Name { get; set; }
        public DateTime CreatetAt { get; set; }= DateTime.Now;
        public virtual Building Building { get; set; }
        public string Description { get; set; }
        public virtual List<MaterialWarehouse> MaterialWarehouse { get; set; } = new List<MaterialWarehouse>();
    }
}
