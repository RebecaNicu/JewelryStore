using JewelryStore.Context;
using JewelryStore.Models;
using JewelryStore.Repositories.Interfaces;

namespace JewelryStore.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(JewelryStoreContext jewelryStoreContext)
            : base(jewelryStoreContext)
        {
        }
    }
}
