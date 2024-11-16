using Domain.Renting.Model.Commands;
using Domain.Renting.Model.Entities;
using Domain.Renting.Model.Queries;
using Domain.Renting.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.Renting.Controllers;
using Presentation.Renting.Resources;

namespace PresentationTest.Renting;

public class ScooterControllerTest
{
    // Test para mostrar todos los scooters
    [Fact]
    public void GetAllScootersMustToBeWorking()
    {
        var scooterQueryService = new Mock<IScooterQueryService>();
        var scooterCommandService = new Mock<IScooterCommandService>();
        var query = new GetAllScootersQuery();
        var scooters = scooterQueryService.Object.Handle(query).Result;
        var scooterEntities = scooters as ScooterEntity[] ?? scooters.ToArray();
        scooterQueryService.Setup(x => x.Handle(query)).ReturnsAsync(scooterEntities);
        var controller = new ScooterController(scooterQueryService.Object, scooterCommandService.Object);
        var result = controller.GetAllScooters().Result as ObjectResult;
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        
    }
    
    [Fact]
    public void AddScooterMustToBeWorking()
    {
        var scooterQueryService = new Mock<IScooterQueryService>();
        var scooterCommandService = new Mock<IScooterCommandService>();
        var controller = new ScooterController(scooterQueryService.Object, scooterCommandService.Object);
        var result = controller.CreateScooter(new CreateScooterResource(
            "Test", 
            "Test", 
            "Test",
            5.5, 
            "Olivos", 
            "987654321", 
            "ytrewqgfd")
        ).Result as ObjectResult;
        Assert.NotNull(result);
        Assert.Equal(201, result.StatusCode);
    }
    
   [Fact]
    public void UpdateScooterMustToBeWorking()
    {
        var scooterQueryService = new Mock<IScooterQueryService>();
        var scooterCommandService = new Mock<IScooterCommandService>();
        var controller = new ScooterController(scooterQueryService.Object, scooterCommandService.Object);
        var result = controller.UpdateScooter(1, new UpdateScooterResource(
            "Test", 
            "Test", 
            "Test", 
            5.5, 
            "Olivos", 
            "987654321", 
            "ytrewqgfd")
        ).Result as ObjectResult;
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }
    
    [Fact]
    public void DeleteScooterMustToBeWorking()
    {
        var scooterQueryService = new Mock<IScooterQueryService>();
        var scooterCommandService = new Mock<IScooterCommandService>();
        var controller = new ScooterController(scooterQueryService.Object, scooterCommandService.Object);
        var result = controller.DeleteScooter(1).Result as ObjectResult;
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }
    
    [Fact]
    public void GetScooterByIdMustToBeWorking()
    {
        var scooterQueryService = new Mock<IScooterQueryService>();
        var scooterCommandService = new Mock<IScooterCommandService>();
        var controller = new ScooterController(scooterQueryService.Object, scooterCommandService.Object);
        var command = new CreateScooterCommand("Test", "Test", "Test", "teersi", 5.5, "987654321", "ytrewqgfd");
        var scooterEntity = new ScooterEntity(command);
        scooterQueryService.Setup(x => x.Handle(new GetScooterByIdQuery(1)))
            .ReturnsAsync(scooterEntity);
        var result = controller.GetScooterById(1).Result as ObjectResult;
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        
    }
    [Fact]
    public void DeleteScooterTest()
    {
        var scooterQueryService = new Mock<IScooterQueryService>(); 
        var scooterCommandService = new Mock<IScooterCommandService>();
        var controller =
            new ScooterController(scooterQueryService.Object,
                scooterCommandService.Object); 

        var scooterId = Guid.NewGuid(); 
        var scooterEntity = new ScooterEntity 
        {
            Name = "Test",
            Brand = "Test",
            Model = "Test",
            Image = "Test",
            PricePerHour = 5.5,
            District = "Olivos",
            Phone = "987654321"
        };
        //a
        scooterQueryService.Setup(x => x.Handle(It.IsAny<GetScooterByIdQuery>()))
            .ReturnsAsync(scooterEntity); 
        
        var result =
            controller.DeleteScooter(1).Result as ObjectResult; 
        Assert.NotNull(result); 
        Assert.Equal(200, result.StatusCode); 
    }
}