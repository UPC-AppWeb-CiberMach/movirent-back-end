using Domain.Review.Model.Entities;
using Domain.Review.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;

namespace Infrastructure.Review;

public class ReviewRepository(AppDbContext context) : BaseRepository<ReviewEntity>(context), IReviewRepository
{
    
}