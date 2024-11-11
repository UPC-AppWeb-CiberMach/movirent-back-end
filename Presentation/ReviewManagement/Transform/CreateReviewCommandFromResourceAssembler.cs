using Domain.Review.Model.Commands;
using Presentation.Review.Resources;

namespace Presentation.Review.Transform;

public static class CreateReviewCommandFromResourceAssembler
{
    public static CreateReviewCommand ToCommandFromResource(CreateReviewResource resource)
    {
        return new CreateReviewCommand( resource.Name,
            resource.Model, resource.Brand, resource.Image,
            resource.PricePerHour, resource.District, resource.Phone);
    }
    
    
}