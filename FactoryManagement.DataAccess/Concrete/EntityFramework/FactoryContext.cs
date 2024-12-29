using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryManagement.Entities.Concrete;
using FactoryManagement.Entities.Concrete.CustomIdentity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace FactoryManagement.DataAccess.Concrete.EntityFramework
{
    public class FactoryContext: IdentityDbContext<AppUser, AppRole, int>
    {
        public FactoryContext(DbContextOptions<FactoryContext> options): base(options)
        {
        }
        

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies();
        //    //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; DataBase=FactoryDb; Trusted_Connection=true");
            
        //}

        public DbSet<Factory> Factories { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialTransaction> MaterialTransactions { get; set; }
        //public DbSet<Personnel> Personnel { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<MaterialWarehouse> MaterialWarehouses { get; set; }



    }
}
