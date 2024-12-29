using FactoryManagement.Core.Entities;
using FactoryManagement.Entities.Concrete.CustomIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Entities.Concrete
{
    public class MaterialRequest:IEntity
    {
        public int MaterialRequestID { get; set; }
        public int Quantity { get; set; }
        public string RequestStatus { get; set; }
        public DateTime RequestTime { get; set; }
        public DateTime ApprovedAt { get; set; }

        public int MaterialWarehouseID { get; set; }
        public virtual MaterialWarehouse MaterialWarehouse { get; set; }

        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
