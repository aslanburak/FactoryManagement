using FactoryManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Entities.Concrete
{
    public class Material:IEntity
    {
        public int MaterialID { get; set; }
        public string Name { get; set; }       
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public string Description { get; set; }

        public virtual ICollection<MaterialWarehouse> MaterialWarehouses { get; set; }=new List<MaterialWarehouse>();

    }
}
