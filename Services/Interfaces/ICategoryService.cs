using JewelryStore.Models;

namespace JewelryStore.Services.Interfaces
{
    public interface ICategoryService
    {
        Category GetCategoryByName(string categoryName);
        Category GetCategoryById(int? categoryId);
        void Create(Category category);
        void Update(int id, Category category);
        void Delete(int id);
        List<Category> GetAllCategories();
    }
}
