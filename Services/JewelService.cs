using JewelryStore.Models;
using JewelryStore.Repositories.Interfaces;
using JewelryStore.Services.Interfaces;

namespace JewelryStore.Services
{
    public class JewelService : IJewelService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public JewelService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void Create(Jewel jewel)
        {
            _repositoryWrapper.JewelRepository.Create(jewel);
            _repositoryWrapper.Save();
        }

        public void Delete(int id)
        {
            _repositoryWrapper.JewelRepository.Delete(GetJewelById(id));
            _repositoryWrapper.Save();
        }

        public List<Jewel> GetAllJewels()
        {
            return _repositoryWrapper.JewelRepository.FindAll().ToList();
        }

        public Jewel GetJewelById(int id)
        {
            return _repositoryWrapper.JewelRepository.FindByCondition(c => c.JewelId == id).First();
        }

        public void Update(int id, Jewel jewel)
        {
            _repositoryWrapper.JewelRepository.Update(jewel);
            _repositoryWrapper.Save();
        }
    }
}
