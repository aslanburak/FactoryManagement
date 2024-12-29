using FactoryManagement.Core.DataAccess.EntityFramework;
using FactoryManagement.DataAccess.Abstract;
using FactoryManagement.Entities.Concrete;
using FactoryManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.DataAccess.Concrete.EntityFramework
{
    public class EfBuildingDal : EfEntityRepositoryBase<Building, FactoryContext>,IBuildingDal
    {
        public EfBuildingDal(FactoryContext context) : base(context)
        {
        }
    }
}
