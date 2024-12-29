using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryManagement.Entities.Concrete;

namespace FactoryManagement.Business.Abstract
{
    public interface IFactoryService
    {
        void Add(Factory factory);
        void Delete(int factoryid);
        void Update(Factory factory);
        List<Factory> GetAll();

        Factory GetById(int factoryid);

    }
}
