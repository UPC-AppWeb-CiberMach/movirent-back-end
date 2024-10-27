using Domain.Renting.Model.Commands;
using Presentation.Renting.Resources;

namespace Presentation.Renting.Transform;

public static class CreateScooterCommandFromResourceAssembler
{
    public static CreateScooterCommand ToCommandFromResource(CreateScooterResource resource)
    {
        return new CreateScooterCommand( resource.Name,
            resource.Model, resource.Brand, resource.Image,
            resource.PricePerHour, resource.District, resource.Phone);
    }
    
    
}