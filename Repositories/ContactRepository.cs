using JewelryStore.Context;
using JewelryStore.Models;
using JewelryStore.Repositories.Interfaces;

namespace JewelryStore.Repositories
{
	public class ContactRepository : RepositoryBase<Contact>, IContactRepository
	{
		public ContactRepository(JewelryStoreContext jewelryStoreContext)
			: base(jewelryStoreContext)
		{
		}
	}
}
