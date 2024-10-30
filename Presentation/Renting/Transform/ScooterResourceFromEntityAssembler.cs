using Domain.Renting.Model.Entities;
using Presentation.Renting.Resources;

namespace Presentation.Renting.Transform;

public class ScooterResourceFromEntityAssembler
{
    public static ScooterResource ToResourceFromEntity(ScooterVehicle entity) =>
        new(entity.Id, entity.Name,
             entity.Brand, entity.Model, entity.PricePerHour, 
             entity.District, entity.Phone, entity.Image
             );
}