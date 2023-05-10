using JewelryStore.Context;
using JewelryStore.Models;
using JewelryStore.Repositories.Interfaces;

namespace JewelryStore.Repositories
{
    public class JewelRepository : RepositoryBase<Jewel>, IJewelRepository
        {
            public JewelRepository(JewelryStoreContext jewelryStoreContext)
                : base(jewelryStoreContext)
            {
            }
    }
}
