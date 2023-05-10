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
    public class JewelCartsController : Controller
    {

        private readonly IJewelCartService _jewelcartService;
        private readonly ICartService _cartService;
        private readonly IJewelService _jewelService;

        public JewelCartsController(IJewelCartService jewelcartService, IJewelService jewelService, ICartService cartService)
        {
            _jewelcartService = jewelcartService;
            _jewelService = jewelService;
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var carts = _jewelcartService.GetAllJewelCarts();
            foreach (var cart in carts)
            {
                cart.Cart = _cartService.GetCartById(cart.CartId);
                cart.Jewel = _jewelService.GetJewelById(cart.JewelId);
            }
            return View(carts);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var carts = _cartService.GetAllCarts();
            ViewBag.CartId = new SelectList(carts, "Id", "TotalAmount");

            var jewels = _jewelService.GetAllJewels();
            ViewBag.JewelId = new SelectList(jewels, "JewelId", "JewelName", "Details", "Price");
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("CartId, JewelId")] JewelCart jewelcart)
        {
            if (ModelState.IsValid)
            {
                _jewelcartService.Create(jewelcart);
                return RedirectToAction(nameof(Index));
            }
            var carts = _cartService.GetAllCarts();
            ViewBag.CartId = new SelectList(carts, "Id", "TotalAmount");

            var jewels = _jewelService.GetAllJewels();
            ViewBag.JewelId = new SelectList(jewels, "JewelId", "JewelName", "Details"); 
            return View(jewels);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var jewelcart = _jewelcartService.GetJewelCartById(id);

            var jewel = _jewelService.GetJewelById(jewelcart.JewelId);
            var cart = _cartService.GetCartById(jewelcart.CartId);

            jewelcart.Jewel = jewel;
            jewelcart.Cart = cart;

            if (jewelcart == null) return View("NotFound");
            return View(jewelcart);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jewelcart = _jewelcartService.GetJewelCartById(id);

            var jewel = _jewelService.GetJewelById(jewelcart.JewelId);
            var cart = _cartService.GetCartById(jewelcart.CartId);

            jewelcart.Jewel = jewel;
            jewelcart.Cart = cart;

            _jewelcartService.Delete(id);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var jewelcart = _jewelcartService.GetJewelCartById(id);

            var jewel = _jewelService.GetJewelById(jewelcart.JewelId);
            var cart = _cartService.GetCartById(jewelcart.CartId);

            var jewels = _jewelService.GetAllJewels();
            ViewBag.JewelId = new SelectList(jewels, "JewelId", "JewelName", "Details");

            var carts = _cartService.GetAllCarts();
            ViewBag.CartId = new SelectList(carts, "Id", "TotalAmount");

            if (jewelcart == null) return View("NotFound");
            return View(jewelcart);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("CartId, JewelId")] JewelCart jewelcart)
        {
            if (ModelState.IsValid)
            {
                _jewelcartService.Update(id, jewelcart);
                return RedirectToAction(nameof(Index));
            }

            var jewels = _jewelService.GetAllJewels();
            ViewBag.JewelId = new SelectList(jewels, "JewelId", "JewelName", "Details");

            var carts = _cartService.GetAllCarts();
            ViewBag.CartId = new SelectList(carts, "Id", "TotalAmount");

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var jewelcart = _jewelcartService.GetJewelCartById(id);
            jewelcart.Jewel = _jewelService.GetJewelById(jewelcart.JewelId);
            jewelcart.Cart = _cartService.GetCartById(jewelcart.CartId);

            if (jewelcart == null) return View("NotFound");

            return View(jewelcart);
        }
    }
}
