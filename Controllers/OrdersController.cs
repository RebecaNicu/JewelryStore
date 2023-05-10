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
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;

        public OrdersController(IOrderService orderService, ICartService cartService)
        {
            _orderService = orderService;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            var orders = _orderService.GetAllOrders();
            foreach (var order in orders)
            {
                order.Cart = _cartService.GetCartById(order.CartId);
            }
            return View(orders);
        }

        public IActionResult Create()
        {
            var carts = _cartService.GetAllCarts();
            ViewBag.CartId = new SelectList(carts, "Id", "TotalAmount");

            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id, Phone, BillingAddress, DeliveryAddress, TotalAmount, CreationDate, Details, CartId")] Order order)
        {
            if (ModelState.IsValid)
            {
                _orderService.Create(order);
                return RedirectToAction(nameof(Index));
            }
            var carts = _cartService.GetAllCarts();
            ViewBag.CartId = new SelectList(carts, "Id", "TotalAmount");

            return View(order);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var order = _orderService.GetOrderById(id);
            var cart = _cartService.GetCartById(order.CartId);
       
            order.Cart = cart;

            if (order == null) return View("NotFound");
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = _orderService.GetOrderById(id);
            var cart = _cartService.GetCartById(order.CartId);

            order.Cart = cart;

            _orderService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var order = _orderService.GetOrderById(id);
            var cart = _cartService.GetCartById(order.CartId);

            var carts = _cartService.GetAllCarts();
            ViewBag.CartId = new SelectList(carts, "Id", "TotalAmount");

            if (order == null) return View("NotFound");
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Phone, BillingAddress, DeliveryAddress, TotalAmount, CreationDate, Details, CartId")] Order order)
        {
            if (ModelState.IsValid)
            {
                _orderService.Update(id, order);
                return RedirectToAction(nameof(Index));
            }

            var categories = _cartService.GetAllCarts();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name", order.CartId);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var order = _orderService.GetOrderById(id);
            var cart = _cartService.GetCartById(order.CartId);

            order.Cart = cart;

            if (order == null) return View("NotFound");

            return View(order);
        }
    }
}
