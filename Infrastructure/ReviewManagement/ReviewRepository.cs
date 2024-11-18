using Domain.ReviewManagement.Model.Entities;
using Domain.ReviewManagement.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;

namespace Infrastructure.Review;

public class ReviewRepository(AppDbContext context) : BaseRepository<ReviewEntity>(context), IReviewRepository
{
    
}