using JewelryStore.Models;

namespace JewelryStore.Services.Interfaces
{
    public interface IJewelService
    {
        void Create(Jewel jewel);
        void Update(int id, Jewel jewel);
        void Delete(int id);
        Jewel GetJewelById(int id);
        List<Jewel> GetAllJewels();
    }
}
