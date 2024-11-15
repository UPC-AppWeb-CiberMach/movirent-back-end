using Domain.Renting.Model.Entities;
using Presentation.Renting.Resources;

namespace Presentation.Renting.Transform;

public class ScooterResourceFromEntityAssembler
{
    public static ScooterResource ToResourceFromEntity(ScooterEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");
        }

        if (string.IsNullOrWhiteSpace(entity.Name) ||
            string.IsNullOrWhiteSpace(entity.Brand) ||
            string.IsNullOrWhiteSpace(entity.Model) ||
            string.IsNullOrWhiteSpace(entity.District) ||
            string.IsNullOrWhiteSpace(entity.Phone) ||
            string.IsNullOrWhiteSpace(entity.Image))
        {
            throw new ArgumentException("Los campos obligatorios de la entidad no pueden estar vacíos.");
        }

        if (entity.PricePerHour <= 0)
        {
            throw new ArgumentException("El precio por hora debe ser mayor a 0.");
        }

        return new ScooterResource(
            entity.Id,
            entity.Name,
            entity.Brand,
            entity.Model,
            entity.PricePerHour,
            entity.District,
            entity.Phone,
            entity.Image
        );
    }
}