using FactoryManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Entities.Concrete
{
    public class MaterialWarehouse:IEntity
    {
        public int MaterialWarehouseID { get; set; }
        public int WarehouseID { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public int MaterialID { get; set; }
        public virtual Material Material { get; set; }

        public int StockQuantity { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual ICollection<MaterialTransaction> MaterialTransactions { get; set; } = new List<MaterialTransaction>();
        public virtual ICollection<MaterialRequest> MaterialRequests { get; set; } = new List<MaterialRequest>();
    }
}
