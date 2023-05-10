using JewelryStore.Models;
using JewelryStore.Repositories;
using JewelryStore.Repositories.Interfaces;
using JewelryStore.Services.Interfaces;
using System.Drawing.Drawing2D;
using System.Linq.Expressions;

namespace JewelryStore.Services
{
    public class CartService : ICartService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CartService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void Create(Cart cart)
        {
            _repositoryWrapper.CartRepository.Create(cart);
            _repositoryWrapper.Save();
        }

        public void Delete(int id)
        {
            _repositoryWrapper.CartRepository.Delete(GetCartById(id));
            _repositoryWrapper.Save();
        }

        public List<Cart> GetAllCarts()
        {
            return _repositoryWrapper.CartRepository.FindAll().ToList();
        }

        public Cart GetCartById(int? cartId)
        {
            return _repositoryWrapper.CartRepository.FindByCondition(c => c.Id == cartId).First();
        }

        public void Update(int id, Cart cart)
        {
            _repositoryWrapper.CartRepository.Update(cart);
            _repositoryWrapper.Save();
        }
    }
}
