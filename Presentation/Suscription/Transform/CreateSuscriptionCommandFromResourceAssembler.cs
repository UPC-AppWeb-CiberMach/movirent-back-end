using Domain.Suscription.Model.Commands;
using Presentation.Suscription.Resources;

namespace Presentation.Suscription.Transform;

public static class CreateSuscriptionCommandFromResourceAssembler
{
    public static CreateSuscriptionCommand ToCommandFromResource(CreateSuscriptionResource resource)
    {
        return new CreateSuscriptionCommand( resource.Name,
            resource.Model, resource.Brand, resource.Image,
            resource.PricePerHour, resource.District, resource.Phone);
    }
    
    
}