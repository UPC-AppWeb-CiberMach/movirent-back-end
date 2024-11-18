
using Domain.Review.Model.Entities;
using Domain.Review.Model.Queries;

namespace Domain.Review.Services;

public interface IReviewQueryService
{
    Task<IEnumerable<ReviewEntity>> Handle(GetAllReviewsQuery query);
}