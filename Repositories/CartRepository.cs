using JewelryStore.Context;
using JewelryStore.Models;
using JewelryStore.Repositories.Interfaces;

namespace JewelryStore.Repositories
{
    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(JewelryStoreContext jewelryStoreContext)
            : base(jewelryStoreContext)
        {
        }
    }
}
