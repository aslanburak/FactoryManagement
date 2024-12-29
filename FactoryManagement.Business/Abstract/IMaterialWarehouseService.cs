using FactoryManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Business.Abstract
{
    public interface IMaterialWarehouseService
    {
        void Add(MaterialWarehouse materialWarehouse);
        void Update(MaterialWarehouse materialWarehouse);
        void Delete(int materialWarehouseId);
        MaterialWarehouse GetById(int materialWarehouseId);
        List<MaterialWarehouse> GetAll();
        List<MaterialWarehouse> GetByWarehouseId(int warehouseId); // Belirli bir depodaki tüm ürünleri döndürece
        List<MaterialWarehouse> GetByMaterialId(int materialId); // Belirli bir ürünün hangi depolarda olduğu döndürecek

    }
}
