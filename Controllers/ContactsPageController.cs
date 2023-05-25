using JewelryStore.Models;
using JewelryStore.Services;
using JewelryStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JewelryStore.Controllers
{
	public class ContactsPageController : Controller
	{
		private readonly IContactService _contactService;

		public ContactsPageController(IContactService contactService)
		{
			_contactService = contactService;
		}

		public ActionResult ContactPage()
		{
			return View();
		}

		// GET: PaginaContact/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: PaginaContact/Create
		public ActionResult Create()
		{
			return View();
		}


		// POST: PaginaContact/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("Id,Name,Email,Message")] Contact contact)
		{

			if (ModelState.IsValid)
			{
				_contactService.Create(contact);
				return RedirectToAction("contact");
			}

			return View(contact);
		}

		// GET: PaginaContact/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: PaginaContact/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: PaginaContact/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: PaginaContact/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
