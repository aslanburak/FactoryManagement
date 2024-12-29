using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryManagement.Entities.Concrete;

namespace FactoryManagement.Business.Abstract
{
    public interface IWarehouseService
    {
        void Add(Warehouse warehouse);
        void Delete(int warehouseId);
        void Update(Warehouse warehouse);
        Warehouse GetById(int warehouseId);
        List<Warehouse> GetAll();
        //Warehouse GetById(int warehouseId); warehouseID ye göre depoyu getirmeye gerek var mı ?
        List<Warehouse> GetByBuildingId(int buildingId);
        List<Warehouse> SearchByName(string warehouseName); //depo ismini göre arama 

    }
}
