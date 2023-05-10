using JewelryStore.Models;

namespace JewelryStore.Services.Interfaces
{
    public interface IBrandService
    {
        Brand GetBrandById(int brandId);
        void Create(Brand brand);
        void Update(int id, Brand brand);
        void Delete(int id);
        List<Brand> GetAllBrands();
    }
}
