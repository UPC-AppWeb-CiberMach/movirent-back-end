using Domain.Review.Model.Entities;
using Presentation.Review.Resources;

namespace Presentation.Review.Transform;

public class ReviewResourceFromEntityAssembler
{
    public static ReviewResource ToResourceFromEntity(ReviewEntity entity) =>
        new(entity.Id, entity.Comment, entity.StarNumb);
}