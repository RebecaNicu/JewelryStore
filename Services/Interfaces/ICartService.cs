using JewelryStore.Models;

namespace JewelryStore.Services.Interfaces
{
    public interface ICartService
    {
        Cart GetCartById(int? cartId);
        void Create(Cart cart);
        void Update(int id, Cart cart);
        void Delete(int id);
        List<Cart> GetAllCarts();
    }
}
