using FactoryManagement.Business.Abstract;
using FactoryManagement.DataAccess.Abstract;
using FactoryManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Business.Concrete
{
    public class FactoryManager : IFactoryService
    {
        IFactoryDal _factoryDal;
        public FactoryManager(IFactoryDal factoryDal)
        {
            _factoryDal = factoryDal;
            
        }
        public void Add(Factory factory)
        {
            _factoryDal.Add(factory);

        }

        public void Delete(int factoryid)
        {
            _factoryDal.Delete(new Factory { FactoryID = factoryid });
        }

        public List<Factory> GetAll()
        {
           return  _factoryDal.GetList();
        }

        public Factory GetById(int factoryid)
        {
            return _factoryDal.Get(f=> f.FactoryID == factoryid);
        }

        public void Update(Factory factory)
        {
            _factoryDal.Update(factory);
        }
    }
}
