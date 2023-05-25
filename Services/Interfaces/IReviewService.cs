using JewelryStore.Models;
using Microsoft.CodeAnalysis;

namespace JewelryStore.Services.Interfaces
{
    public interface IReviewService
    {
        List<Review> GetReviewsByStarValue(float starValue);
        void Create(Review review);
        void Update(int id, Review review);
        void Delete(int id);
        List<Review> GetAllReviews();
        Review GetReviewById(int id);

	}
}
