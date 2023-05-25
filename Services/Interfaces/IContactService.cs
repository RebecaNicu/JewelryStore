using JewelryStore.Models;

namespace JewelryStore.Services.Interfaces
{
	public interface IContactService
	{
		Contact GetContactById(int? conactId);
		void Create(Contact contact);
		void Update(int id, Contact contact);
		void Delete(int id);
		List<Contact> GetAllContacts();
	}
}
