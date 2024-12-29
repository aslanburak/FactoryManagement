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
    public class EfMaterialTransactionDal : EfEntityRepositoryBase<MaterialTransaction, FactoryContext>, IMaterialTransactionDal
    {
        public EfMaterialTransactionDal(FactoryContext context) : base(context)
        {
        }
    }
}
