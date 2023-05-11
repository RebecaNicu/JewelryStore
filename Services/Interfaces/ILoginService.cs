using JewelryStore.Models;
using Microsoft.AspNetCore.Identity;

namespace JewelryStore.Services.Interfaces
{
    public interface ILoginService
    {
        Task<bool> LoginByUser(User user);
        Task<SignInResult> LoginAsync(string email, string password, bool rememberMe);
    }

}
