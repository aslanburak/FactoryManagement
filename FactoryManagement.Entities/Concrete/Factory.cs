using FactoryManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Entities.Concrete
{
    public class Factory:IEntity
    {
        public int FactoryID { get; set; }
 
        public string Name { get; set; } 

        public string Location { get; set; } 
       
        public string Description { get; set; }

        public virtual ICollection<Building> Buildings { get; set; } = new List<Building>();

    }
}
