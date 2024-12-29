using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryManagement.Core.DataAccess.EntityFramework;
using FactoryManagement.DataAccess.Abstract;
using FactoryManagement.Entities.Concrete;

namespace FactoryManagement.DataAccess.Concrete.EntityFramework
{
    public class EfTransactionDal:EfEntityRepositoryBase<MaterialTransaction,FactoryContext>,ITransactionDal
    {
        public EfTransactionDal(FactoryContext context) : base(context)
        {
        }
    }
}
