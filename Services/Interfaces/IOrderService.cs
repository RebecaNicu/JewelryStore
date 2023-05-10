using JewelryStore.Models;

namespace JewelryStore.Services.Interfaces
{
    public interface IOrderService
    {
        void Create(Order order);
        void Update(int id, Order order);
        void Delete(int id);
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
    }
}
