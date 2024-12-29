using FactoryManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Entities.Concrete
{
    public class Building:IEntity
    {
        
        public int BuildingID { get; set; }
        
        public string Name { get; set; } 
        public DateTime CreateTime { get; set; } = DateTime.Now;
       
        public int FactoryID { get; set; }
        
        public virtual Factory Factory { get; set; }

        public string Description { get; set; } 
        
        public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();

    }
}
