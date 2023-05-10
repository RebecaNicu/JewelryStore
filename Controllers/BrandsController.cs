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
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace JewelryStore.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class BrandsController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandssService)
        {
            _brandService = brandssService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var brands = _brandService.GetAllBrands();
            return View(brands);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            _brandService.Create(brand);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var brandsDetails = _brandService.GetBrandById(id);
            if (brandsDetails == null) return View("NotFound");
            return View(brandsDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brandsDetails = _brandService.GetBrandById(id);
            if (brandsDetails == null) return View("NotFound");

            _brandService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var brand = _brandService.GetBrandById(id);
            if (brand == null) return View("NotFound");
            return View(brand);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("BrandId,Name, Description")] Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return View(brand);
            }
            _brandService.Update(id, brand);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var categoryDetails = _brandService.GetBrandById(id);

            if (categoryDetails == null) return View("NotFound");
            return View(categoryDetails);
        }
    }
}
