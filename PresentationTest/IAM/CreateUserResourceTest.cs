using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Presentation.IAM.Resources;
using Xunit;

public class CreateUserResourceTest
{
    [Fact]
    public void Post_CreateNewUser_ValidInputTest()
    {
        var email = "velarde@gmail.com";
        var password = "velarde123";
        var completeName = "Nestor Velarde";
        var phone = "987654321"; 
        var dni = "87654321";
        var photo = "miProfile.com";
        var address = "Los Olivos";
        var role = "Admin"; // Añadir el parámetro faltante

        var createUserResource = new CreateUserResource(email, password, completeName, phone, dni, photo, address, role);
        
        Assert.Equal(email, createUserResource.email);
        Assert.Equal(password, createUserResource.password);
        Assert.Equal(completeName, createUserResource.completeName);
        Assert.Equal(phone, createUserResource.phone);
        Assert.Equal(dni, createUserResource.dni);
        Assert.Equal(photo, createUserResource.photo);
        Assert.Equal(address, createUserResource.address);
        Assert.Equal(role, createUserResource.role); 
    }

    [Fact]
    public void Post_CreateNewUserTest_InvalidDate()
    {
        var email = "velardeail.com";
        var password = "velarde123";
        var completeName = "Nestor Velarde";
        var phone = "987654321987654321";
        var dni = "123";
        var photo = "miProfile.com";
        var address = "Los Olivos";
        var role = "Client"; 

        var createUserResource = new CreateUserResource(email, password, completeName, phone, dni, photo, address, role);
        
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(createUserResource);
        
        bool isValid = Validator.TryValidateObject(createUserResource, validationContext, validationResults, true);
        
        Assert.False(isValid); 
    }
}