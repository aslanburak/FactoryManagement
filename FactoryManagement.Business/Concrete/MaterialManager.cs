using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryManagement.DataAccess.Concrete.EntityFramework;
using FactoryManagement.Business.Abstract;
using FactoryManagement.DataAccess.Abstract;
using FactoryManagement.Entities.Concrete;

namespace FactoryManagement.Business.Concrete
{
    public class MaterialManager:IMaterialService
    {
        IMaterialDal _materialDal;
        public MaterialManager(IMaterialDal materialDal)
        {
            _materialDal = materialDal;
        }

        public void Add(Material material)
        {
            _materialDal.Add(material);
        }

        public void Delete(int materialId)
        {
            _materialDal.Delete(new Material { MaterialID = materialId });
        }
        public void Update(Material material)
        {
            _materialDal.Update(material);

        }

        public List<Material> GetAll()
        {
            return _materialDal.GetList();
        }

        public Material GetById(int materialId)
        {
            return _materialDal.Get(m=>m.MaterialID == materialId);
        }
       
        public List<Material> SearchByName(string name)
        {
            return _materialDal.GetList(m => m.Name.Contains(name));

        }

        
    }
}
