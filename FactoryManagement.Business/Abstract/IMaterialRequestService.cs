using FactoryManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Business.Abstract
{
    public interface IMaterialRequestService
    {
        void Add(MaterialRequest materialRequest);
        void Update(MaterialRequest materialRequest);
        void Delete(int materialRequestId);
        List<MaterialRequest> GetAll();

        MaterialRequest GetById(int materialRequestId);
       List< MaterialRequest> GetByRequestStatus(string requestStatus);
    }
}
