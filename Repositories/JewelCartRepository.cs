using JewelryStore.Context;
using JewelryStore.Models;
using JewelryStore.Repositories.Interfaces;

namespace JewelryStore.Repositories
{
    public class JewelCartRepository : RepositoryBase<JewelCart>, IJewelCartRepository
    {
        public JewelCartRepository(JewelryStoreContext jewelryStoreContext)
            : base(jewelryStoreContext)
        {
        }
    }
}
