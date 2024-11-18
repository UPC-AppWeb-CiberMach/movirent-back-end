using Application.IAM.QueryServices;
using Domain.IAM.Model.Entities;
using Domain.IAM.Model.Queries;
using Domain.IAM.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.IAM.controller;
using Presentation.IAM.Resources;


namespace PresentationTest.IAM;

public class UserControllerTest
{
    [Fact]
    public void Get_AllUsersTest()
    {
        var userQueryService = new Mock<IUserQueryService>(); 
        var userCommandService = new Mock<IUserCommandService>(); 
        var query = new GetAllUsersQuery(); 
        var users = userQueryService.Object.Handle(query).Result; 
        var userEntities = users as UserProfile[] ?? users.ToArray(); 
        userQueryService.Setup(x => x.Handle(query))
            .ReturnsAsync(userEntities); 
        var controller =
            new UserController(userQueryService.Object,
                userCommandService.Object); 
        var result = controller.GetAllUsers().Result as ObjectResult; 
        
        // Esperamos que el resultado no sea nulo y que el código de estado sea 200
        Assert.NotNull(result); 
        Assert.Equal(200, result.StatusCode); 
    }
    
    [Fact]
    public void Post_NewUserTest()
    {
        var userQueryService = new Mock<IUserQueryService>(); 
        var userCommandService = new Mock<IUserCommandService>(); 
        var controller =
            new UserController(userQueryService.Object,
                userCommandService.Object); 
        var result = controller.CreateUser(new CreateUserResource( 
            "velarde@gmail.com",
            "velarde123",
            "Nestor Velarde",
            "987654321",
            "87654321",
            "miProfile.com",
            "Los Olivos",
            "Admin"
        )).Result as ObjectResult;
      
        // Esperamos que el resultado no sea nulo y que el código de estado sea 201
        Assert.NotNull(result); 
        Assert.Equal(201, result.StatusCode); 
    }
    
    [Fact]
    public async Task Get_UserByIdTest()
    {
        var userQueryService = new Mock<IUserQueryService>();
        var userCommandService = new Mock<IUserCommandService>(); 
        var controller = new UserController(userQueryService.Object, userCommandService.Object); // Crea una instancia de UserController

        var userId = Guid.NewGuid(); 
        var userProfile = new UserProfile 
        {
            Id = userId,
            Email = "test@example.com",
            Password = "Password",
            CompleteName = "Test User",
            Phone = "1234567890",
            Dni = "12345678",
            Photo = "path/to/photo.jpg",
            Address = "123 Test St, Test City"
        };
        
        userQueryService.Setup(x => x.Handle(It.IsAny<GetUsersByIdQuery>()))
            .ReturnsAsync(userProfile); 
        
        var result = await controller.GetUserById(1) as ObjectResult; 
        
        // Esperamos que el resultado no sea nulo y que el código de estado sea 200
        Assert.NotNull(result); 
        Assert.Equal(200, result.StatusCode); 
    }
    
    [Fact]
    public async Task Put_UserByIdTest()
    {
        var userQueryService = new Mock<IUserQueryService>(); 
        var userCommandService = new Mock<IUserCommandService>(); 
        var controller =
            new UserController(userQueryService.Object,
                userCommandService.Object); 

        var userId = Guid.NewGuid(); 
        var userProfile = new UserProfile 
        {
            Id = userId,
            Email = "velader@gmail.com",
            Password = "Password123",
            CompleteName = "Nestor Velarde",
            Phone = "987654321",
            Dni = "12345678",
            Photo = "miProfile.com",
            Address = "Los Olivos 123"
        };

        var updateUserResource =
            new UpdateUserResource( 
                "velardeNestor@gmail.com",
                "Password123",
                "Nestor Velarde",
                "987654321",
                "12345678",
                "miProfile.com",
                "Los Olivos 123"
            );
        
        userQueryService.Setup(x => x.Handle(It.IsAny<GetUsersByIdQuery>()))
            .ReturnsAsync(userProfile); 
        
        var result = await controller.UpdateUser(1, updateUserResource) as ObjectResult; 
        
        // Esperamos que el resultado no sea nulo y que el código de estado sea 200
        Assert.NotNull(result); 
        Assert.Equal(200, result.StatusCode); 
    }
    
   
    [Fact]
    public async Task Delete_UserByIdTest()
    {
        var userQueryService = new Mock<IUserQueryService>(); 
        var userCommandService = new Mock<IUserCommandService>(); 
        var controller =
            new UserController(userQueryService.Object,
                userCommandService.Object); 

        var userId = Guid.NewGuid(); 
        var userProfile = new UserProfile
        {
            Id = userId,
            Email = "velarde@gmail.com",
            Password = "87654321",
            CompleteName = "Nestor veladre",
            Phone = "987654321",
            Dni = "87654321",
            Photo = "miProfile.com",
            Address = "Los Olivos"
        };
        
        userQueryService.Setup(x => x.Handle(It.IsAny<GetUsersByIdQuery>()))
            .ReturnsAsync(userProfile); 
        
        var result = await controller.DeleteUser(1) as ObjectResult;
        
        // Esperamos que el resultado no sea nulo y que el código de estado sea 200
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode); 
    }
}