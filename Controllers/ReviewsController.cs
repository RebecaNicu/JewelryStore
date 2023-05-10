using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JewelryStore.Context;
using JewelryStore.Models;
using JewelryStore.Exceptions;
using Microsoft.CodeAnalysis;
using JewelryStore.Services.Interfaces;
using JewelryStore.Services;

namespace JewelryStore.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IJewelService _jewelService;

        public ReviewsController(IReviewService reviewService, IJewelService jewelService)
        {
            _reviewService = reviewService;
            _jewelService = jewelService;
        }

        public IActionResult Index()
        {
            var reviews = _reviewService.GetAllReviews();
            foreach (var review in reviews)
            {
                review.Jewel = _jewelService.GetJewelById(review.JewelId);
            }
            return View(reviews);
        }

        public IActionResult Create()
        { 
            var jewels = _jewelService.GetAllJewels();
            ViewBag.JewelId = new SelectList(jewels, "JewelId", "JewelName");
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("ReviewId,Title,Body,StarValue,JewelId")] Review review)
        {
            if (ModelState.IsValid)
            {
                _reviewService.Create(review);
                return RedirectToAction(nameof(Index));
            }

            var jewels = _jewelService.GetAllJewels();
            ViewBag.JewelId = new SelectList(jewels, "JewelId", "JewelName");
            return View(review);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var reviewsDetails = _reviewService.GetReviewById(id);
            var jewels = _jewelService.GetAllJewels();
            ViewBag.JewelId = new SelectList(jewels, "JewelId", "JewelName");

            if (reviewsDetails == null) return View("NotFound");
            return View(reviewsDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewId,Title,Body,StarValue,JewelId")] Review review)
        {
            if (ModelState.IsValid)
            {
                _reviewService.Update(id, review);
                return RedirectToAction(nameof(Index));
            }
            var jewels = _jewelService.GetAllJewels();
            ViewBag.JewelId = new SelectList(jewels, "JewelId", "JewelName");
            return View(review);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var review = _reviewService.GetReviewById(id);

            var jewel = _jewelService.GetJewelById(review.JewelId);

            review.Jewel = jewel;

            if (review == null) return View("NotFound");
            return View(review);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = _reviewService.GetReviewById(id);
            var jewel = _jewelService.GetJewelById(review.JewelId);

            review.Jewel = jewel;

            _reviewService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var review = _reviewService.GetReviewById(id);
            review.Jewel = _jewelService.GetJewelById(review.JewelId);

            if (review == null) return View("NotFound");

             return View(review);
        }
    }
}
