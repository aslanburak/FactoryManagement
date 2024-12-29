using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FactoryManagement.Core.Entities;
namespace FactoryManagement.Entities.Concrete.CustomIdentity
{
    public class AppUser:IdentityUser<int>, IEntity
    {
        public int AppUserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<MaterialTransaction> MaterialTransactions { get; set; } = new List<MaterialTransaction>();
        public virtual ICollection<MaterialRequest> MaterialRequests { get; set; } = new List<MaterialRequest>();

    }
    
}
