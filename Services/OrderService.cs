using JewelryStore.Models;
using JewelryStore.Repositories.Interfaces;
using JewelryStore.Services.Interfaces;

namespace JewelryStore.Services
{
    public class OrderService : IOrderService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public OrderService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void Create(Order order)
        {
            _repositoryWrapper.OrderRepository.Create(order);
            _repositoryWrapper.Save();
        }

        public void Delete(int id)
        {
            _repositoryWrapper.OrderRepository.Delete(GetOrderById(id));
            _repositoryWrapper.Save();
        }

        public List<Order> GetAllOrders()
        {
            return _repositoryWrapper.OrderRepository.FindAll().ToList();
        }

        public Order GetOrderById(int id)
        {
            return _repositoryWrapper.OrderRepository.FindByCondition(o => o.Id == id).First();
        }

        public void Update(int id, Order order)
        {
            _repositoryWrapper.OrderRepository.Update(order);
            _repositoryWrapper.Save();
        }
    }
}
