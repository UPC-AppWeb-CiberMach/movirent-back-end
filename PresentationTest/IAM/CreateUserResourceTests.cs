using System.ComponentModel.DataAnnotations;
using Presentation.IAM.Resources;

namespace PresentationTest.IAM;

public class CreateUserResourceTests
{
    [Fact]
        public void CreateUserResource()
        {
            var validUser = new CreateUserResource(
                email: "velarde.com",
                password: "6543211",
                completeName: "Vanesa Doe",
                phone: "123456789",
                dni: "12345678",
                photo: "photo.png",
                address: "123 Street Name"
            );
            
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(validUser, new ValidationContext(validUser), validationResults, true);
            
            Assert.True(isValid);
            Assert.Empty(validationResults);
        }

        [Fact]
        public void CreateUserResource_InvalidEmail_ReturnsValidationError()
        {
            var invalidUser = new CreateUserResource(
                email: "invalid",
                password: "ValidPassword1",
                completeName: "Teresita Olivrea",
                phone: "123456789",
                dni: "12345678",
                photo: "photo.png",
                address: "123 Street Name"
            );
            
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(invalidUser, new ValidationContext(invalidUser), validationResults, true);
            
            Assert.False(isValid);
            Assert.Contains(validationResults, vr => vr.MemberNames.Contains("email"));
        }

        [Fact]
        public void CreateUserResource_InvalidPassword_ReturnsValidationError()
        {
           
            var invalidUser = new CreateUserResource(
                email: "test@example.com",
                password: "short", 
                completeName: "Juan Garcia",
                phone: "123456789",
                dni: "12345678",
                photo: "photo.png",
                address: "123 Street Name"
            );
            
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(invalidUser, new ValidationContext(invalidUser), validationResults, true);
            
            Assert.False(isValid);
            Assert.Contains(validationResults, vr => vr.MemberNames.Contains("password"));
        }

        [Fact]
        public void CreateUserResource_InvalidPhone_ReturnsValidationError()
        {
            var invalidUser = new CreateUserResource(
                email: "test@example.com",
                password: "ValidPassword1",
                completeName: "John Doe",
                phone: "123", 
                dni: "12345678",
                photo: "photo.png",
                address: "123 Street Name"
            );
            
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(invalidUser, new ValidationContext(invalidUser), validationResults, true);
            
            Assert.False(isValid);
            Assert.Contains(validationResults, vr => vr.MemberNames.Contains("phone"));
        }
}