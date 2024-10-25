using Domain.Scooter.Model.Commands;
using Presentation.Scooter.Resources;

namespace Presentation.Scooter.Transform;

public static class CreateScooterCommandFromResourceAssembler
{
    public static CreateScooterCommand ToCommandFromResource(CreateScooterResource resource)
    {
        return new CreateScooterCommand( resource.Name,
            resource.Model, resource.Brand, resource.Image,
            resource.PricePerHour, resource.District, resource.Phone);
    }
    
    
}