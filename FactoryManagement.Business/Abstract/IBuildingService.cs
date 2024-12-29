using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryManagement.Entities.Concrete;
namespace FactoryManagement.Business.Abstract
{
    public interface IBuildingService
    {
        void Add(Building building);
        void Delete(int buildingId);
        void Update(Building building);
        Building GetById(int buildingId);
        List<Building> GetAll();

        List<Building> GetByFactoryId(int factoryId); 
    }
}
