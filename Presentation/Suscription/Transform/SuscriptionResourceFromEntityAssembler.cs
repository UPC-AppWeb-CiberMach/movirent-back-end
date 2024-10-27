using Domain.Suscription.Model.Entities;
using Presentation.Suscription.Resources;

namespace Presentation.Suscription.Transform;

public class SuscriptionResourceFromEntityAssembler
{
    public static SuscriptionResource ToResourceFromEntity(SuscriptionEntity entity) =>
        new(entity.Id, entity.Name,
             entity.Brand, entity.Model, entity.PricePerHour, 
             entity.District, entity.Phone, entity.Image
             );
}