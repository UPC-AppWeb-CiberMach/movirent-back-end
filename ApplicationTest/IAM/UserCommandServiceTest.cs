using Application.IAM.CommandServices;
using Domain.IAM.Model.Commands;
using Domain.IAM.Model.Entities;
using Domain.IAM.Repositories;
using Domain.Shared;
using Moq;
using NSubstitute;
using Domain.IAM.Services;

namespace ApplicationTest.IAM;

public class UserCommandServiceTest
{
    [Fact]
    public void CreateUserTest()
    {
        
        
        // Arrange
        
        var usersRepository = new Mock<IUsersRepository>();
        var unitOfWork = new Mock<IUnitOfWork>();
        var encryptService = new Mock<IEncryptService>();
        var tokenService = new Mock<ITokenService>();
        var userCommandService = new UserCommandService(usersRepository.Object, unitOfWork.Object, encryptService.Object, tokenService.Object);
        var command = new SingUpCommand(
            "velarde@gmail.com",
            "8765432112",
            "terews",
            "987654321",
            "87654321",
            "mifoto",
            "Los Olivos",
            "Admin");
        
        // Act
        var result = userCommandService.Handle(command);
        
        // Assert
        Assert.NotNull(result);

    }
}