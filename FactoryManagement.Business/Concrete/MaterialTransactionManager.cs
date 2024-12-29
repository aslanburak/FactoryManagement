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
    public class MaterialTransactionManager : IMaterialTransactionService
    {
        private readonly IMaterialTransactionDal _materialTransactionDal;

        public MaterialTransactionManager(IMaterialTransactionDal materialTransactionDal)
        {
            _materialTransactionDal = materialTransactionDal;
        }

        public MaterialTransaction GetById(int materialTransactionId)
        {
            return _materialTransactionDal.Get(mt => mt.MaterialTransactionID == materialTransactionId);
        }

        public List<MaterialTransaction> GetAll()
        {
            return _materialTransactionDal.GetList();
        }

        public void Add(MaterialTransaction materialTransaction)
        {
            _materialTransactionDal.Add(materialTransaction);
        }

        public void Update(MaterialTransaction materialTransaction)
        {
            _materialTransactionDal.Update(materialTransaction);
        }

        public void Delete(int materialTransactionId)
        {
             _materialTransactionDal.Delete(new MaterialTransaction { MaterialTransactionID = materialTransactionId });
            
        }

        public List<MaterialTransaction> GetByUserId(int userId)
        {
            return _materialTransactionDal.GetList(mt => mt.AppUserId == userId);
        }
    }
}
