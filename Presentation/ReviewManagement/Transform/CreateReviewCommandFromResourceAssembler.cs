using Domain.ReviewManagement.Model.Commands;
using Presentation.Review.Resources;
using Presentation.ReviewManagement.Resources;

namespace Presentation.Review.Transform;

public static class CreateReviewCommandFromResourceAssembler
{
    public static CreateReviewCommand ToCommandFromResource(CreateReviewResource resource)
    {
        return new CreateReviewCommand( resource.Comment, resource.StarNumb);
    }
    
    
}