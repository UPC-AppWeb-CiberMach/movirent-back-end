using Domain.Suscription.Model.Entities;
using Presentation.Suscription.Resources;

namespace Presentation.Suscription.Transform;

public class SuscriptionResourceFromEntityAssembler
{
    public static SuscriptionResource ToResourceFromEntity(SuscriptionEntity entity) =>
        new(entity.Id, entity.Name,
             entity.Description, entity.Stars, entity.Price);
}