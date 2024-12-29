using FactoryManagement.Core.DataAccess.EntityFramework;
using FactoryManagement.DataAccess.Abstract;
using FactoryManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.DataAccess.Concrete.EntityFramework
{
    public class EfMaterialWarehouseDal : EfEntityRepositoryBase<MaterialWarehouse, FactoryContext>, IMaterialWarehouseDal
    {
        public EfMaterialWarehouseDal(FactoryContext context) : base(context)
        {
        }
    }
}
