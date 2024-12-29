using FactoryManagement.Core.DataAccess;
using FactoryManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.DataAccess.Abstract
{
    public interface IWarehouseDal:IEntityRepository<Warehouse>
    {
    }
}
