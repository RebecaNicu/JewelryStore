using JewelryStore.Exceptions;
using JewelryStore.Models;
using JewelryStore.Repositories;
using JewelryStore.Repositories.Interfaces;
using JewelryStore.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace JewelryStore.Services
{
    public class ReviewService : IReviewService
    {
        private IRepositoryWrapper _repositoryWrapper;
		private readonly UserManager<User> _userManager;

        public ReviewService(IRepositoryWrapper repositoryWrapper, UserManager<User> userManager)
        {
            _repositoryWrapper = repositoryWrapper;
            _userManager = userManager;
        }

        public void Create(Review review)
        {
            _repositoryWrapper.ReviewRepository.Create(review);
            _repositoryWrapper.Save();
        }

        public List<Review> GetReviewsByStarValue(float starValue)
        {
            var reviews = new List<Review>();

            reviews = _repositoryWrapper.ReviewRepository.FindByCondition(r => r.StarValue == starValue).ToList();

            return reviews;
        }

        public List<Review> GetAllReviews()
        {
            return _repositoryWrapper.ReviewRepository.FindAll().ToList();
        }

        public void Update(int id, Review review)
        {
            _repositoryWrapper.ReviewRepository.Update(review);
            _repositoryWrapper.Save();
        }

        public void Delete(int id)
        {
            _repositoryWrapper.ReviewRepository.Delete(GetReviewById(id));
            _repositoryWrapper.Save();
        }

        public Review GetReviewById(int id)
        {
            return _repositoryWrapper.ReviewRepository.FindByCondition(r => r.ReviewId == id).First();
        }

	}
}
