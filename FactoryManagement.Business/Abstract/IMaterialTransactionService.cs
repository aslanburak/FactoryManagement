using FactoryManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Business.Abstract
{
    public interface IMaterialTransactionService
    {
        MaterialTransaction GetById(int id);
        List<MaterialTransaction> GetAll();
        void Add(MaterialTransaction materialTransaction);
        void Update(MaterialTransaction materialTransaction);
        void Delete(int id);
        List<MaterialTransaction> GetByUserId(int userId);
    }
}
