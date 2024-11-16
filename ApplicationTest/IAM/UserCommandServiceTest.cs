using Application.IAM.CommandServices;
using Domain.IAM.Model.Commands;
using Domain.IAM.Model.Entities;
using Domain.IAM.Repositories;
using Domain.Shared;
using Moq;
using NSubstitute;

namespace ApplicationTest.IAM;

public class UserCommandServiceTest
{
    [Fact]
    public void CreateUserTest()
    {
        // Arrange
        var usersRepository = new Mock<IUsersRepository>();
        var unitOfWork = new Mock<IUnitOfWork>();
        var userCommandService = new UserCommandService(usersRepository.Object, unitOfWork.Object);
        var command = new CreateUserCommand(
            "velarde@gmail.com",
            "8765432112",
            "terews",
            "987654321",
            "87654321",
            "mifoto",
            "Los Olivos");
        
        // Act
        var result = userCommandService.Handle(command);
        
        // Assert
        Assert.NotNull(result);

    }
}