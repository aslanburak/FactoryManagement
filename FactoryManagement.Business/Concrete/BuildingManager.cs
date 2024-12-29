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
    public class BuildingManager : IBuildingService
    {
        IBuildingDal _buildingDal;
        public BuildingManager(IBuildingDal buildingDal)
        {
            _buildingDal = buildingDal;
            
        }
        public void Add(Building building)
        {
            _buildingDal.Add(building);
        }

        public void Delete(int buildingId)
        {
            _buildingDal.Delete(new Building { BuildingID = buildingId });
           
        }

        public List<Building> GetAll()
        {
           return _buildingDal.GetList();
        }

        public List<Building> GetByFactoryId(int factoryId)
        {
           return _buildingDal.GetList(f=>f.FactoryID==factoryId);
        }

        public Building GetById(int buildingId)
        {
            return _buildingDal.Get(b=>b.BuildingID==buildingId);
        }

        public void Update(Building building)
        {
            _buildingDal.Update(building);
        }

    }
}
