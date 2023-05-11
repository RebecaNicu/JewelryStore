using JewelryStore.Models;
using JewelryStore.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace JewelryStore.Services
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<LoginService> _logger;

        public LoginService(SignInManager<User> signInManager, ILogger<LoginService> logger, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<bool> LoginByUser(User user)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);

            return true;
        }

        public async Task<SignInResult> LoginAsync(string email, string password, bool rememberMe)
        {
            var user = await _userManager.FindByEmailAsync(email);

            // Check if the user exists
            if (user == null)
            {
                return SignInResult.Failed;
            }
           

            var result = await _signInManager.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");
            }
            return result;
        }
    }

}
