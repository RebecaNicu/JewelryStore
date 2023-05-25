using JewelryStore.Context;
using JewelryStore.Repositories.Interfaces;

namespace JewelryStore.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private JewelryStoreContext _jeweleryContext;
        private IReviewRepository? _reviewRepository;
        private ICategoryRepository? _categoryRepository;
        private IJewelRepository? _jewelRepository;
        private IBrandRepository? _brandRepository;
        private ICartRepository? _cartRepository;
        private IJewelCartRepository? _jewelcartRepository;
        private IOrderRepository? _orderRepository;
        private IJewelOrderRepository? _jewelorderRepository;
		private IContactRepository? _contactRepository;

		public IContactRepository ContactRepository
		{
			get
			{
				if (_contactRepository == null)
				{
					_contactRepository = new ContactRepository(_jeweleryContext);
				}

				return _contactRepository;
			}
		}

		public IJewelOrderRepository JewelOrderRepository
        {
            get
            {
                if (_jewelorderRepository == null)
                {
                    _jewelorderRepository = new JewelOrderRepository(_jeweleryContext);
                }

                return _jewelorderRepository;
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_jeweleryContext);
                }

                return _orderRepository;
            }
        }

        public ICartRepository CartRepository
        {
            get
            {
                if (_cartRepository == null)
                {
                    _cartRepository = new CartRepository(_jeweleryContext);
                }

                return _cartRepository;
            }
        }

        public IJewelCartRepository JewelCartRepository
        {
            get
            {
                if (_jewelcartRepository == null)
                {
                    _jewelcartRepository = new JewelCartRepository(_jeweleryContext);
                }

                return _jewelcartRepository;
            }
        }

        public IJewelRepository JewelRepository
        {
            get
            {
                if (_jewelRepository == null)
                {
                    _jewelRepository = new JewelRepository(_jeweleryContext);
                }

                return _jewelRepository;
            }
        }

        public IBrandRepository BrandRepository
        {
            get
            {
                if (_brandRepository == null)
                {
                    _brandRepository = new BrandRepository(_jeweleryContext);
                }

                return _brandRepository;
            }
        }

        public IReviewRepository ReviewRepository
        {
            get
            {
                if (_reviewRepository == null)
                {
                    _reviewRepository = new ReviewRepository(_jeweleryContext);
                }

                return _reviewRepository;
            }
        }

        public ICategoryRepository CategoryRepository 
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_jeweleryContext);
                }

                return _categoryRepository;
            }
        } 

        public RepositoryWrapper(JewelryStoreContext jewelryStoreContext)
        {
            _jeweleryContext = jewelryStoreContext;
        }

        public void Save()
        {
            _jeweleryContext.SaveChanges();
        }
    }
}
