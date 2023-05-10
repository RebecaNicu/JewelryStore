using JewelryStore.Models;

namespace JewelryStore.Services.Interfaces
{
    public interface IJewelOrderService
    {
        JewelOrder GetJewelOrderById(int jewelOrderId);
        void Create(JewelOrder jewelOrder);
        void Update(int id, JewelOrder jewelOrder);
        void Delete(int id);
        List<JewelOrder> GetAllJewelOrders();
    }
}
