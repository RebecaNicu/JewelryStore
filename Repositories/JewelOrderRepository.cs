using JewelryStore.Context;
using JewelryStore.Models;
using JewelryStore.Repositories.Interfaces;

namespace JewelryStore.Repositories
{
    public class JewelOrderRepository : RepositoryBase<JewelOrder>, IJewelOrderRepository
    {
        public JewelOrderRepository(JewelryStoreContext jewelryStoreContext)
            : base(jewelryStoreContext)
        {
        }
    }
}
