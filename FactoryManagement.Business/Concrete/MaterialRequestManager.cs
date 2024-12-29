using FactoryManagement.Business.Abstract;
using FactoryManagement.DataAccess.Abstract;
using FactoryManagement.DataAccess.Concrete.EntityFramework;
using FactoryManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Business.Concrete
{
    public class MaterialRequestManager : IMaterialRequestService
    {
        IMaterialRequestDal _materialRequestDal;

        public MaterialRequestManager(IMaterialRequestDal materialRequestDal)
        {
            _materialRequestDal = materialRequestDal;
        }

        public void Add(MaterialRequest materialRequest)
        {
            _materialRequestDal.Add(materialRequest);
        }

        public void Delete(int materialRequestId)
        {
            _materialRequestDal.Delete(GetById(materialRequestId)); 
        }

        public List<MaterialRequest> GetAll()
        {
           return  _materialRequestDal.GetList();
        }

        public MaterialRequest GetById(int materialRequestId)
        {
            return _materialRequestDal.Get(mt => mt.MaterialRequestID == materialRequestId);
        }

        public void Update(MaterialRequest materialRequest)
        {
            _materialRequestDal.Update(materialRequest);
        }
    }
}
