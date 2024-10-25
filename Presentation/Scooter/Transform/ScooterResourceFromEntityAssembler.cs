using Presentation.Scooter.Resources;

namespace Presentation.Scooter.Transform;

public class ScooterResourceFromEntityAssembler
{
    public static ScooterResource ToResourceFromEntity(Scooter entity) =>
        new ScooterResource(entity.Id, entity.Name,
            entity.Model, entity.Brand, entity.Image,
            entity.PricePerHour, entity.District, entity.Phone);
}