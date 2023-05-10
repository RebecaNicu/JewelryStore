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

namespace JewelryStore.Controllers
{
    public class JewelsController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IJewelService _jewelService;
        private readonly IBrandService _brandService;

        public JewelsController(ICategoryService categoryService, IJewelService jewelService, IBrandService brandService)
        {
            _categoryService = categoryService;
            _jewelService = jewelService;
            _brandService = brandService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var jewels = _jewelService.GetAllJewels();
            foreach (var jewel in jewels)
            {
                jewel.Category = _categoryService.GetCategoryById(jewel.CategoryId);
                jewel.Brand = _brandService.GetBrandById(jewel.BrandId);
            }
            return View(jewels);
        }

        public IActionResult Create()
        {
            var categories = _categoryService.GetAllCategories();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name");

            var brands = _brandService.GetAllBrands();
            ViewBag.BrandId = new SelectList(brands, "BrandId", "Name", "Description");
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("JewelId, JewelName, Details, Price, CategoryId, BrandId")] Jewel jewel)
        {
            if (ModelState.IsValid)
            {
                _jewelService.Create(jewel);
                return RedirectToAction(nameof(Index));
            }
            var categories = _categoryService.GetAllCategories();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name", jewel.CategoryId);

            var brands = _brandService.GetAllBrands();
            ViewBag.BrandId= new SelectList(brands, "BrandId", "Name", "Description");
            return View(jewel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var jewelsDetails = _jewelService.GetJewelById(id);

            var category = _categoryService.GetCategoryById(jewelsDetails.CategoryId);
            var brand = _brandService.GetBrandById(jewelsDetails.BrandId);

            jewelsDetails.Category = category;
            jewelsDetails.Brand = brand;

            if (jewelsDetails == null) return View("NotFound");
            return View(jewelsDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jewel = _jewelService.GetJewelById(id);
            var category = _categoryService.GetCategoryById(jewel.CategoryId);
            var brand = _brandService.GetBrandById(jewel.BrandId);

            jewel.Category = category;
            jewel.Brand = brand;

            _jewelService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var jewelsDetails = _jewelService.GetJewelById(id);

            var category = _categoryService.GetCategoryById(jewelsDetails.CategoryId);
            var brand = _brandService.GetBrandById(jewelsDetails.BrandId);

            var categories = _categoryService.GetAllCategories();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name");

            var brands = _brandService.GetAllBrands();
            ViewBag.BrandId = new SelectList(brands, "BrandId", "Name", "Description");

            if (jewelsDetails == null) return View("NotFound");
            return View(jewelsDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("JewelId, JewelName, Details, Price, CategoryId, BrandId")] Jewel jewel)
        {
            if (ModelState.IsValid)
            {
                _jewelService.Update(id, jewel);
                return RedirectToAction(nameof(Index));
            }

            var categories = _categoryService.GetAllCategories();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name", jewel.CategoryId);

            var brands = _brandService.GetAllBrands();
            ViewBag.BrandId = new SelectList(brands, "BrandId", "Name", "Description");

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var jewel = _jewelService.GetJewelById(id);
            jewel.Brand = _brandService.GetBrandById(jewel.BrandId);
            jewel.Category = _categoryService.GetCategoryById(jewel.CategoryId);

            if (jewel == null) return View("NotFound");

            return View(jewel);
        }

    }
}
