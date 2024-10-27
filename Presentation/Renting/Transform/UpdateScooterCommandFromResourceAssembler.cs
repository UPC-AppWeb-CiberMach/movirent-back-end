using Domain.Scooter.Model.Commands;
using Presentation.Renting.Resources;

namespace Presentation.Renting.Transform;

public class UpdateScooterCommandFromResourceAssembler
{
    public static UpdateScooterCommand ToCommandFromResource(int id, UpdateScooterResource resource)
    {
        return new UpdateScooterCommand(id, resource.Name,
            resource.Model, resource.Brand, resource.Image,
            resource.PricePerHour, resource.District, resource.Phone);
    }
    
}