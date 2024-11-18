using Domain.ReviewManagement.Model.Entities;
using Domain.ReviewManagement.Model.Queries;
using Domain.ReviewManagement.Repositories;
using Domain.ReviewManagement.Services;

namespace Application.Review.QueryServices;

public class ReviewQueryService : IReviewQueryService
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewQueryService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<IEnumerable<ReviewEntity>> Handle(GetAllReviewsQuery query)
    {
        return await _reviewRepository.GetAllAsync();
    }
}