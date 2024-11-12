using Domain.IAM.Model.Entities;
using Presentation.IAM.Resources;

namespace Presentation.IAM.Transform;

public class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(UserProfile entity)
    {
        return new UserResource(entity.id, entity.email, entity.password, 
            entity.completeName, entity.phone, entity.dni, entity.photo, entity.address);
    }
}