using Domain.IAM.Model.Commands;
using Presentation.IAM.Resources;
using System.Security.Cryptography;
using System.Text;


namespace Presentation.IAM.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUserCommand ToCommandFromResource(CreateUserResource resource)
    {
        return new CreateUserCommand(
            resource.email,
            HashPassword(resource.password), 
            resource.completeName, 
            resource.phone,
            resource.dni, 
            resource.photo, 
            resource.address);
    }
    
    private static string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
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