using JewelryStore.Models;

namespace JewelryStore.Services.Interfaces
{
    public interface IJewelCartService
    {
        JewelCart GetJewelCartById(int? jewelCartId);
        void Create(JewelCart jewelCart);
        void Update(int id, JewelCart jewelCart);
        void Delete(int id);
        List<JewelCart> GetAllJewelCarts();
    }
}
