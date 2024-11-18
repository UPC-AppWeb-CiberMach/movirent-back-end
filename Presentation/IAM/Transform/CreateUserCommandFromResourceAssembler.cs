using Domain.IAM.Model.Commands;
using Presentation.IAM.Resources;

namespace Presentation.IAM.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static SingUpCommand ToCommandFromResource(CreateUserResource resource)
    {
        return new SingUpCommand(
            resource.email,
            resource.password, 
            resource.completeName, 
            resource.phone,
            resource.dni, 
            resource.photo, 
            resource.address,
            resource.role);
    }
}


/*
 * public partial class UserProfile
    {
    public int id { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string completeName { get; set; }
    public string phone { get; set; }
    public string dni { get; set; }
    public string photo { get; set; }
    public string address { get; set; }
 */