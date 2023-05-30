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
using System.Numerics;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace JewelryStore.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoriesService)
        {
            _categoryService = categoriesService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _categoryService.GetAllCategories();
           return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _categoryService.Create(category);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var categoriesDetails = _categoryService.GetCategoryById(id);
            if (categoriesDetails == null) return View("NotFound");
            return View(categoriesDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriesDetails = _categoryService.GetCategoryById(id);
            if (categoriesDetails == null) return View("NotFound");

             _categoryService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var categoriesDetails = _categoryService.GetCategoryById(id);
            if (categoriesDetails == null) return View("NotFound");
            return View(categoriesDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,Name")] Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            _categoryService.Update(id, category);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var categoryDetails = _categoryService.GetCategoryById(id);

            if (categoryDetails == null) return View("NotFound");
            return View(categoryDetails);
        }
    }
}
