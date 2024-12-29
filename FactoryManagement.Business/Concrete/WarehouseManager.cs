using FactoryManagement.Business.Abstract;
using FactoryManagement.Entities.Concrete;
using FactoryManagement.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryManagement.DataAccess.Concrete.EntityFramework;

namespace FactoryManagement.Business.Concrete
{
    public class WarehouseManager : IWarehouseService
    {
        IWarehouseDal _warehouseDal;
        public WarehouseManager(IWarehouseDal warehouseDal)
        {
              _warehouseDal = warehouseDal;
            
        }

        public void Add(Warehouse warehouse)
        {
            _warehouseDal.Add(warehouse);
        }

        public void Delete(int warehouseId)
        {
            _warehouseDal.Delete(new Warehouse{ WarehouseID=warehouseId });
        }

        public List<Warehouse> GetAll()
        {
            return _warehouseDal.GetList();
        }

        public List<Warehouse> GetByBuildingId(int buildingId)
        {
            return _warehouseDal.GetList(b=>b.BuildingID==buildingId);
        }

        public Warehouse GetById(int warehouseId)
        {
           return  _warehouseDal.Get(w=>w.WarehouseID==warehouseId);
        }

        
        public List<Warehouse> SearchByName(string warehouseName)
        {
            return _warehouseDal.GetList(w => w.Name.Contains(warehouseName));
        }

        public void Update(Warehouse warehouse)
        {
            _warehouseDal.Update(warehouse);
        }
    }
}
