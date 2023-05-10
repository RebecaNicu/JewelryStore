using JewelryStore.Models;
using JewelryStore.Repositories.Interfaces;
using JewelryStore.Services.Interfaces;

namespace JewelryStore.Services
{
    public class JewelCartService : IJewelCartService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public JewelCartService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void Create(JewelCart jewelCart)
        {
            _repositoryWrapper.JewelCartRepository.Create(jewelCart);
            _repositoryWrapper.Save();
        }

        public void Delete(int id)
        {
            _repositoryWrapper.JewelCartRepository.Delete(GetJewelCartById(id));
            _repositoryWrapper.Save();
        }

        public List<JewelCart> GetAllJewelCarts()
        {
            return _repositoryWrapper.JewelCartRepository.FindAll().ToList();
        }

        public JewelCart GetJewelCartById(int? jewelCartId)
        {
            return _repositoryWrapper.JewelCartRepository.FindByCondition(c => c.Id == jewelCartId).First();
        }

        public void Update(int id, JewelCart jewelCart)
        {
            _repositoryWrapper.JewelCartRepository.Update(jewelCart);
            _repositoryWrapper.Save();
        }
    }
}
