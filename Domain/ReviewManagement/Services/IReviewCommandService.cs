using Domain.ReviewManagement.Model.Commands;

namespace Domain.ReviewManagement.Services;

public interface IReviewCommandService
{
    Task<int> Handle(CreateReviewCommand command);
}