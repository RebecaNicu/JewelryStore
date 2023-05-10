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
    public class JewelOrdersController : Controller
    {

        private readonly IJewelOrderService _jewelorderService;
        private readonly IOrderService _orderService;
        private readonly IJewelService _jewelService;

        public JewelOrdersController(IJewelOrderService jewelorderService, IJewelService jewelService, IOrderService orderService)
        {
            _jewelorderService = jewelorderService;
            _jewelService = jewelService;
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var jewelOrders = _jewelorderService.GetAllJewelOrders();
            foreach (var jewelOrder in jewelOrders)
            {
                jewelOrder.Order = _orderService.GetOrderById(jewelOrder.OrderId);
                jewelOrder.Jewel = _jewelService.GetJewelById(jewelOrder.JewelId);
            }
            return View(jewelOrders);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var orders = _orderService.GetAllOrders();
            ViewBag.OrderId = new SelectList(orders, "Id", "BillingAddress", "TotalAmount");

            var jewels = _jewelService.GetAllJewels();
            ViewBag.JewelId = new SelectList(jewels, "JewelId", "JewelName", "Details", "Price");
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("OrderId, JewelId")] JewelOrder jewelorder)
        {
            if (ModelState.IsValid)
            {
                _jewelorderService.Create(jewelorder);
                return RedirectToAction(nameof(Index));
            }
            var orders = _orderService.GetAllOrders();
            ViewBag.OrderId = new SelectList(orders, "Id", "BillingAddress", "TotalAmount");

            var jewels = _jewelService.GetAllJewels();
            ViewBag.JewelId = new SelectList(jewels, "JewelId", "JewelName", "Details");

            return View(jewels);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var jewelorder = _jewelorderService.GetJewelOrderById(id);

            var jewel = _jewelService.GetJewelById(jewelorder.JewelId);
            var order = _orderService.GetOrderById(jewelorder.OrderId);

            jewelorder.Jewel = jewel;
            jewelorder.Order = order;

            if (jewelorder == null) return View("NotFound");
            return View(jewelorder);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jewelorder = _jewelorderService.GetJewelOrderById(id);

            var jewel = _jewelService.GetJewelById(jewelorder.JewelId);
            var order = _orderService.GetOrderById(jewelorder.OrderId);

            jewelorder.Jewel = jewel;
            jewelorder.Order = order;

            _jewelorderService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var jewelorder = _jewelorderService.GetJewelOrderById(id);

            var jewel = _jewelService.GetJewelById(jewelorder.JewelId);
            var order = _orderService.GetOrderById(jewelorder.OrderId);

            var jewels = _jewelService.GetAllJewels();
            ViewBag.JewelId = new SelectList(jewels, "JewelId", "JewelName", "Details");

            var orders = _orderService.GetAllOrders();
            ViewBag.OrderId = new SelectList(orders, "Id", "BillingAddress", "TotalAmount");

            if (jewelorder == null) return View("NotFound");
            return View(jewelorder);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId, JewelId")] JewelOrder jewelorder)
        {
            if (ModelState.IsValid)
            {
                _jewelorderService.Update(id, jewelorder);
                return RedirectToAction(nameof(Index));
            }

            var jewels = _jewelService.GetAllJewels();
            ViewBag.JewelId = new SelectList(jewels, "JewelId", "JewelName", "Details");

            var orders = _orderService.GetAllOrders();
            ViewBag.OrderId = new SelectList(orders, "Id", "BillingAddress", "TotalAmount");

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var jewelorder = _jewelorderService.GetJewelOrderById(id);
            jewelorder.Jewel = _jewelService.GetJewelById(jewelorder.JewelId);
            jewelorder.Order = _orderService.GetOrderById(jewelorder.OrderId);

            if (jewelorder == null) return View("NotFound");

            return View(jewelorder);
        }
    }
}
