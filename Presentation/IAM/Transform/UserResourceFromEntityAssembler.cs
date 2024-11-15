using Domain.IAM.Model.Entities;
using Presentation.IAM.Resources;

namespace Presentation.IAM.Transform;

public class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(UserProfile entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");
        }

        if (string.IsNullOrWhiteSpace(entity.email) || 
            string.IsNullOrWhiteSpace(entity.completeName) || 
            string.IsNullOrWhiteSpace(entity.phone) || 
            string.IsNullOrWhiteSpace(entity.dni) || 
            string.IsNullOrWhiteSpace(entity.address))
        {
            throw new ArgumentException("Los campos obligatorios de la entidad no pueden estar vacíos.");
        }

        return new UserResource(entity.id, entity.email, entity.password, 
            entity.completeName, entity.phone, entity.dni, entity.photo, entity.address);
    }
}