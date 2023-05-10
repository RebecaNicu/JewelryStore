using JewelryStore.Models;
using JewelryStore.Repositories.Interfaces;
using JewelryStore.Services.Interfaces;

namespace JewelryStore.Services
{
    public class JewelOrderService : IJewelOrderService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public JewelOrderService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void Create(JewelOrder jewelOrder)
        {
            _repositoryWrapper.JewelOrderRepository.Create(jewelOrder);
            _repositoryWrapper.Save();
        }

        public void Delete(int id)
        {
            _repositoryWrapper.JewelOrderRepository.Delete(GetJewelOrderById(id));
            _repositoryWrapper.Save();
        }

        public List<JewelOrder> GetAllJewelOrders()
        {
            return _repositoryWrapper.JewelOrderRepository.FindAll().ToList();
        }

        public JewelOrder GetJewelOrderById(int jewelOrderId)
        {
            return _repositoryWrapper.JewelOrderRepository.FindByCondition(jo => jo.Id == jewelOrderId).First();
        }

        public void Update(int id, JewelOrder jewelOrder)
        {
            _repositoryWrapper.JewelOrderRepository.Update(jewelOrder);
            _repositoryWrapper.Save();
        }
    }
}
