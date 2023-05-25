using JewelryStore.Models;
using JewelryStore.Services;
using JewelryStore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace JewelryStore.Controllers
{
    public class JewelsPageController : Controller
    {
        
            private readonly IJewelService _jewelService;
            private readonly ICategoryService _categoryService;
            private readonly IBrandService _bandService;

            // GET: ProdusePagina
            public JewelsPageController(IJewelService jewelService)
            {
                _jewelService = jewelService;
            }

            public ActionResult jewelPage()
            {
                ViewData["Jewels"] = _jewelService.GetAllJewels();
                //ViewData["Category"] = _categoryService.GetAllCategories();
                //ViewData["Brand"] = _bandService.GetAllBrands();

            return View();
            }

            // GET: ProdusePagina/Details/5
            public ActionResult Details(int id)
            {
                return View();
            }

            // GET: ProdusePagina/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: ProdusePagina/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(IFormCollection collection)
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

            // GET: ProdusePagina/Edit/5
            public ActionResult Edit(int id)
            {
                return View();
            }

            // POST: ProdusePagina/Edit/5
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

            // GET: ProdusePagina/Delete/5
            public ActionResult Delete(int id)
            {
                return View();
            }

            // POST: ProdusePagina/Delete/5
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
