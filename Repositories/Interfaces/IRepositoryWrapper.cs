namespace JewelryStore.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IReviewRepository ReviewRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IJewelRepository JewelRepository { get; }
        IBrandRepository BrandRepository { get; }
        ICartRepository CartRepository { get; }
        IJewelCartRepository JewelCartRepository { get; }
        IOrderRepository OrderRepository { get; }
        IJewelOrderRepository JewelOrderRepository { get; }
        void Save();
    }
}
