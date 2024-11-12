using Domain.IAM.Model.Entities;
using Presentation.IAM.Resources;

namespace Presentation.IAM.Transform;

public abstract class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(UserProfile entity)
    {
        return new UserResource(entity.Id, entity.Email, entity.Password, 
            entity.CompleteName, entity.Phone, entity.Dni, entity.Photo, entity.Address);
    }
}