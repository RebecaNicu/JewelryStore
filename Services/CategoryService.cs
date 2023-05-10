using JewelryStore.Models;
using JewelryStore.Repositories.Interfaces;
using JewelryStore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JewelryStore.Services
{
    public class CategoryService : ICategoryService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CategoryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void Create(Category category)
        {
            _repositoryWrapper.CategoryRepository.Create(category);
            _repositoryWrapper.Save();
        }

        public void Delete(int id)
        {
            _repositoryWrapper.CategoryRepository.Delete(GetCategoryById(id));
            _repositoryWrapper.Save();
        }

        public Category GetCategoryByName(string name)
        {
            return _repositoryWrapper.CategoryRepository.FindByCondition(c => c.Name == name).First();

        }

        public Category GetCategoryById(int? id)
        {
            return _repositoryWrapper.CategoryRepository.FindByCondition(c => c.CategoryId == id).First();

        }

        public void Update(int id, Category category)
        {
            _repositoryWrapper.CategoryRepository.Update(category);
            _repositoryWrapper.Save();
        }

        List<Category> ICategoryService.GetAllCategories()
        {
            return _repositoryWrapper.CategoryRepository.FindAll().ToList();
        }
    }
}
