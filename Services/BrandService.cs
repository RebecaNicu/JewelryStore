using JewelryStore.Models;
using JewelryStore.Repositories.Interfaces;
using JewelryStore.Services.Interfaces;

namespace JewelryStore.Services
{
    public class BrandService : IBrandService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public BrandService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void Create(Brand brand)
        {
            _repositoryWrapper.BrandRepository.Create(brand);
            _repositoryWrapper.Save();
        }

        public void Delete(int id)
        {
            _repositoryWrapper.BrandRepository.Delete(GetBrandById(id));
            _repositoryWrapper.Save();
        }

        public List<Brand> GetAllBrands()
        {
            return _repositoryWrapper.BrandRepository.FindAll().ToList();
        }

        public Brand GetBrandById(int brandId)
        {
            return _repositoryWrapper.BrandRepository.FindByCondition(c => c.BrandId == brandId).First();
        }

        public void Update(int id, Brand brand)
        {
            _repositoryWrapper.BrandRepository.Update(brand);
            _repositoryWrapper.Save();
        }
    }
}
