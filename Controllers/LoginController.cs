using JewelryStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JewelryStore.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password, bool rememberMe)
        {
            var result = await _loginService.LoginAsync(email, password, rememberMe);

            if (result.Succeeded)
            {
                // redirect to homepage or previous page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View();
            }
        }
    }
}
