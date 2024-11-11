using Domain.Review.Model.Entities;
using Presentation.Review.Resources;

namespace Presentation.Review.Transform;

public class ReviewResourceFromEntityAssembler
{
    public static ReviewResource ToResourceFromEntity(ReviewEntity entity) =>
        new(entity.Id, entity.Name,
             entity.Brand, entity.Model, entity.PricePerHour, 
             entity.District, entity.Phone, entity.Image
             );
}