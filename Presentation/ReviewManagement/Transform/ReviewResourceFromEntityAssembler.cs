using Domain.Review.Model.Entities;
using Presentation.Review.Resources;

namespace Presentation.Review.Transform;

public class ReviewResourceFromEntityAssembler
{
    public static ReviewResource ToResourceFromEntity(ReviewEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "La entidad de la reseña no puede ser nula.");
        }

        if (string.IsNullOrWhiteSpace(entity.Comment))
        {
            throw new ArgumentException("El comentario de la reseña no puede estar vacío.");
        }

        if (entity.StarNumb < 1 || entity.StarNumb > 5)
        {
            throw new ArgumentException("La cantidad de estrellas debe estar entre 1 y 5.");
        }

        return new ReviewResource(entity.Id, entity.Comment, entity.StarNumb);
    }
}