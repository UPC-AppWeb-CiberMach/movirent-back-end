using Domain.Review.Model.Entities;
using Domain.Review.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;

namespace Infrastructure.Review;
/// <summary>
/// Repositorio de reseñas
/// </summary>
public class ReviewRepository(AppDbContext context) : BaseRepository<ReviewEntity>(context), IReviewRepository
{
    
}