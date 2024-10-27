using Domain.Suscription.Model.Commands;
using Presentation.Suscription.Resources;

namespace Presentation.Suscription.Transform;

public static class CreateSuscriptionCommandFromResourceAssembler
{
    public static CreateSuscriptionCommand ToCommandFromResource(CreateSuscriptionResource resource)
    {
        return new CreateSuscriptionCommand( resource.Name,
            resource.Description, resource.Stars, resource.Price);
    }
    
    
}