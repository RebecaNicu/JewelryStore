using JewelryStore.Context;
using JewelryStore.Models;
using JewelryStore.Repositories.Interfaces;

namespace JewelryStore.Repositories
{
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(JewelryStoreContext jewelryStoreContext)
            : base(jewelryStoreContext)
        {
        }
    }
}
