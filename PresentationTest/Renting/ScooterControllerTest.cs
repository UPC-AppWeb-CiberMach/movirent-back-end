﻿using Domain.Renting.Model.Commands;
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
    public void Get_AllScooterTest()
    {
        var scooterQueryService = new Mock<IScooterQueryService>();
        var scooterCommandService = new Mock<IScooterCommandService>();
        var query = new GetAllScootersQuery();
        var scooters = scooterQueryService.Object.Handle(query).Result;
        var scooterEntities = scooters as ScooterEntity[] ?? scooters.ToArray();
        scooterQueryService.Setup(x => x.Handle(query)).ReturnsAsync(scooterEntities);
        var controller = new ScooterController(scooterQueryService.Object, scooterCommandService.Object);
        var result = controller.GetAllScooters().Result as ObjectResult;
        
        // Esperamos que el resultado no sea nulo y que el código de estado sea 200
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        
    }
    
    [Fact]
    public void Post_CreateNewScooterTest()
    {
        var scooterQueryService = new Mock<IScooterQueryService>();
        var scooterCommandService = new Mock<IScooterCommandService>();
        var controller = new ScooterController(scooterQueryService.Object, scooterCommandService.Object);
        var result = controller.CreateScooter(new CreateScooterResource(
            "Scooter Sport", 
            "Yamaha", 
            "Modelo 2021",
            5.5, 
            "Olivos", 
            "987654321", 
            "PhotoScooter")
        ).Result as ObjectResult;
        // Esperamos que el resultado no sea nulo y que el código de estado sea 201
        Assert.NotNull(result);
        Assert.Equal(201, result.StatusCode);
    }
    
   [Fact]
    public void Put_UpdateScooterTest()
    {
        var scooterQueryService = new Mock<IScooterQueryService>();
        var scooterCommandService = new Mock<IScooterCommandService>();
        var controller = new ScooterController(scooterQueryService.Object, scooterCommandService.Object);
        var result = controller.UpdateScooter(1, new UpdateScooterResource(
            "Scooter Sport", 
            "Yamaha", 
            "Modelo 2021",
            5.5, 
            "Olivos", 
            "987654321", 
            "PhotoScooter")
        ).Result as ObjectResult;
        
        // Esperamos que el resultado no sea nulo y que el código de estado sea 200
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }
    
    [Fact]
    public void Delete_ScooterTest()
    {
        var scooterQueryService = new Mock<IScooterQueryService>();
        var scooterCommandService = new Mock<IScooterCommandService>();
        var controller = new ScooterController(scooterQueryService.Object, scooterCommandService.Object);
        var result = controller.DeleteScooter(1).Result as ObjectResult;
        
        // Esperamos que el resultado no sea nulo y que el código de estado sea 200
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }
    
    [Fact]
    public void Get_ScooterByIdTest()
    {
        var scooterQueryService = new Mock<IScooterQueryService>();
        var scooterCommandService = new Mock<IScooterCommandService>();
        var controller = new ScooterController(scooterQueryService.Object, scooterCommandService.Object);
        var command = new CreateScooterCommand(
            "Scooter Sport", 
            "Yamaha", 
            "Modelo 2021", 
            "PhotoScooter", 
            5.5, 
            "Los Olivos", 
            "987654321");
        var scooterEntity = new ScooterEntity(command);
        scooterQueryService.Setup(x => x.Handle(new GetScooterByIdQuery(1)))
            .ReturnsAsync(scooterEntity);
        var result = controller.GetScooterById(1).Result as ObjectResult;
        
        // Esperamos que el resultado no sea nulo y que el código de estado sea 200
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
            Name = "Scoter Sport",
            Brand = "Yamaha",
            Model = "Modelo 2021",
            Image = "PhotoScooter",
            PricePerHour = 5.5,
            District = "SMP",
            Phone = "987654321"
        };
        scooterQueryService.Setup(x => x.Handle(It.IsAny<GetScooterByIdQuery>()))
            .ReturnsAsync(scooterEntity); 
        
        var result = controller.DeleteScooter(1).Result as ObjectResult; 
        
        // Esperamos que el resultado no sea nulo y que el código de estado sea 200
        Assert.NotNull(result); 
        Assert.Equal(200, result.StatusCode); 
    }
}