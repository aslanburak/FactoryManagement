using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryManagement.Entities.Concrete;

namespace FactoryManagement.Business.Abstract
{
    public interface IMaterialService
    {
        List<Material> GetAll();
        void Add(Material material);
        void Update(Material material);
        void Delete(int materialId);

        Material GetById(int materialId);
        
        List<Material> SearchByName(string name); 



    }
}
