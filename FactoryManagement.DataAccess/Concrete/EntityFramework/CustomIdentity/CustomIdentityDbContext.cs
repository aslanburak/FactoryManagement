//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using FactoryManagement.Entities.Concrete.CustomIdentity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;

//namespace FactoryManagement.DataAccess.Concrete.EntityFramework.CustomIdentity
//{
//   public class CustomIdentityDbContext:IdentityDbContext<AppUser,AppRole,int>
//    {
//       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//           optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; DataBase=FactoryDb; Trusted_Connection=true");
//       }
//    }
//}
