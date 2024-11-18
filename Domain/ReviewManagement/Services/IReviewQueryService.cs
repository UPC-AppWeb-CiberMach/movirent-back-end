using Domain.ReviewManagement.Model.Entities;
using Domain.ReviewManagement.Model.Queries;

namespace Domain.ReviewManagement.Services;

public interface IReviewQueryService
{
    Task<IEnumerable<ReviewEntity>> Handle(GetAllReviewsQuery query);
}