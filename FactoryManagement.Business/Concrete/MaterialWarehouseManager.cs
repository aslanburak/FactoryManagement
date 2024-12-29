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
    public class MaterialWarehouseManager : IMaterialWarehouseService
    {
        IMaterialWarehouseDal _materialWarehouseDal;

        public MaterialWarehouseManager(IMaterialWarehouseDal materialWarehouseDal)
        {
            _materialWarehouseDal = materialWarehouseDal;
        }
        public void Add(MaterialWarehouse materialWarehouse)
        {
            // Depoda aynı ürünü kontrol et
            var existingMaterialWarehouse = _materialWarehouseDal.Get(mw =>
                mw.WarehouseID == materialWarehouse.WarehouseID &&
                mw.MaterialID == materialWarehouse.MaterialID);

            if (existingMaterialWarehouse != null)
            {
                // Ürün zaten varsa, stoğu artır
                existingMaterialWarehouse.StockQuantity += materialWarehouse.StockQuantity;
                _materialWarehouseDal.Update(existingMaterialWarehouse);
            }
            else
            {
                // Ürün yoksa yeni kayıt oluştur
                _materialWarehouseDal.Add(materialWarehouse);
            }
        }

        public void Delete(int materialWarehouseId)
        {
            _materialWarehouseDal.Delete(new MaterialWarehouse { MaterialWarehouseID = materialWarehouseId });
        }
        public void Update(MaterialWarehouse materialWarehouse)
        {
            _materialWarehouseDal.Update(materialWarehouse);
        }

        public List<MaterialWarehouse> GetAll()
        {
            return _materialWarehouseDal.GetList();
        }

        public MaterialWarehouse GetById(int materialWarehouseId)
        {
            return _materialWarehouseDal.Get(mw=>mw.MaterialWarehouseID== materialWarehouseId);
        }

        public List<MaterialWarehouse> GetByMaterialId(int materialId)
        {
            return _materialWarehouseDal.GetList(mw => mw.MaterialID == materialId);
        }

        public List<MaterialWarehouse> GetByWarehouseId(int warehouseId)
        {
            return _materialWarehouseDal.GetList(mw => mw.WarehouseID == warehouseId);
        }

        
    }
}
