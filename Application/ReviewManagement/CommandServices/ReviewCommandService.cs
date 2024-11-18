using Domain.Review.Model.Commands;
using Domain.Review.Model.Entities;
using Domain.Review.Repositories;
using Domain.Review.Services;
using Domain.Review.Services;
using Domain.Review.Model.Commands;
using Domain.Shared;

namespace Application.Review.CommandServices;

/// <summary>
/// Servicio de comandos para reseñas
/// </summary>

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
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command), "El comando de creación de reseña no puede ser nulo.");
        }
        
        if (string.IsNullOrWhiteSpace(command.Comment) || command.Comment.Length > 200)
        {
            throw new ArgumentException("El comentario no puede estar vacío y debe tener menos de 200 caracteres.");
        }

        if (command.StarNumb < 1 || command.StarNumb > 5)
        {
            throw new ArgumentException("La cantidad de estrellas debe estar entre 1 y 5.");
        }

        try
        {
            var review = new ReviewEntity(command);
            await _reviewRepository.AddAsync(review);
            await _unitOfWork.CompleteAsync();
            return review.Id;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error al manejar el comando de creación de reseña.", ex);
        }
    }
}