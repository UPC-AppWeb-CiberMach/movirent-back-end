using Domain.Review.Model.Commands;
using Domain.Review.Model.Entities;
using Domain.Review.Repositories;
using Domain.Review.Services;
using Domain.Review.Services;
using Domain.Review.Model.Commands;
using Domain.Shared;

namespace Application.Review.CommandServices;

public class ReviewCommandService : IReviewCommandService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReviewCommandService(IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
    {
        _reviewRepository = reviewRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateReviewCommand command)
    {
        var review = new ReviewEntity(command);
        
        await _reviewRepository.AddAsync(review);
        await _unitOfWork.CompleteAsync();
        return review.Id;
    }
}