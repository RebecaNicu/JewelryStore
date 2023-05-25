using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JewelryStore.Context;
using JewelryStore.Models;
using JewelryStore.Services.Interfaces;
using JewelryStore.Services;

namespace JewelryStore.Controllers
{
    public class ContactsController : Controller
    {
		private readonly IContactService _contactService;

		public ContactsController(IContactService contactService)
		{
			_contactService = contactService;
		}

		[HttpGet]
		public IActionResult Index()
        {
			var contacts = _contactService.GetAllContacts();
			return View(contacts);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Contact contact)
		{
			_contactService.Create(contact);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int id)
		{
			var contactsDetails = _contactService.GetContactById(id);
			if (contactsDetails == null) return View("NotFound");
			return View(contactsDetails);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var contactsDetails = _contactService.GetContactById(id);
			if (contactsDetails == null) return View("NotFound");

			_contactService.Delete(id);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(int id)
		{
			var categoriesDetails = _contactService.GetContactById(id);
			if (categoriesDetails == null) return View("NotFound");
			return View(categoriesDetails);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Message")] Contact contact)
		{
			if (!ModelState.IsValid)
			{
				return View(contact);
			}
			_contactService.Update(id, contact);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Details(int id)
		{
			var contactDetails = _contactService.GetContactById(id);

			if (contactDetails == null) return View("NotFound");
			return View(contactDetails);
		}
	}
}
