using Domain.Review.Model.Commands;
using Domain.Review.Model.Commands;

namespace Domain.Review.Services;

public interface IReviewCommandService
{
    Task<int> Handle(CreateReviewCommand command);
}