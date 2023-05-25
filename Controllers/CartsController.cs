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
    public class CartsController : Controller
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartsService)
        {
            _cartService = cartsService;
        }

		[Authorize(Roles = "USER")]
		public IActionResult Index()
        {
            var carts = _cartService.GetAllCarts();
            return View(carts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cart cart)
        {
            _cartService.Create(cart);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cart = _cartService.GetCartById(id);
            if (cart == null) return View("NotFound");
            return View(cart);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart = _cartService.GetCartById(id);
            if (cart == null) return View("NotFound");

            _cartService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cart = _cartService.GetCartById(id);
            if (cart == null) return View("NotFound");
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TotalAmount")] Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return View(cart);
            }
            _cartService.Update(id, cart);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var cart = _cartService.GetCartById(id);

            if (cart == null) return View("NotFound");
            return View(cart);
        }
    }
}
