using Domain.Review.Model.Entities;
using Domain.Review.Model.Queries;
using Domain.Review.Repositories;
using Domain.Review.Services;

namespace Application.Review.QueryServices;

/// <summary>
/// Servicio de consultas de reviews
/// </summary>
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