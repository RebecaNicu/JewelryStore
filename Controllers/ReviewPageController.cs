using JewelryStore.Services;
using JewelryStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JewelryStore.Controllers
{

    public class ReviewPageController : Controller
    {
        private IJewelService _jewelService;
        private IReviewService _reviewService;

        public ReviewPageController(IJewelService jewelService, IReviewService reviewService)
        {
            _jewelService = jewelService;
            _reviewService = reviewService;
        }

        public IActionResult ReviewPage(int jewelId)
        {
            ViewData["Jewel"] = _jewelService.GetJewelById(jewelId);
            ViewData["Reviews"] = _reviewService.GetAllReviews();

            return View();
        }
    }
}
