using JewelryStore.Models;
using JewelryStore.Models.DTO;

namespace JewelryStore.Services.Interfaces
{
    public interface IRegisterService
    {
        Task<User> RegisterUserAsync(RegisterDTO input);
    }

}
