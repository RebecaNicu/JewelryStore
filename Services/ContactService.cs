using JewelryStore.Models;
using JewelryStore.Repositories.Interfaces;
using JewelryStore.Services.Interfaces;

namespace JewelryStore.Services
{
	public class ContactService : IContactService
	{
		private IRepositoryWrapper _repositoryWrapper;

		public ContactService(IRepositoryWrapper repositoryWrapper)
		{
			_repositoryWrapper = repositoryWrapper;
		}

		public void Create(Contact contact)
		{
			_repositoryWrapper.ContactRepository.Create(contact);
			_repositoryWrapper.Save();
		}

		public Contact GetContactById(int? conactId)
		{
			return _repositoryWrapper.ContactRepository.FindByCondition(c => c.Id == conactId).First();
		}

		public void Update(int id, Contact contact)
		{
			_repositoryWrapper.ContactRepository.Update(contact);
			_repositoryWrapper.Save();
		}

		public List<Contact> GetAllContacts()
		{
			return _repositoryWrapper.ContactRepository.FindAll().ToList();
		}

		public void Delete(int id)
		{
			_repositoryWrapper.ContactRepository.Delete(GetContactById(id));
			_repositoryWrapper.Save();
		}
	}
}
