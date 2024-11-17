using Domain.UserHistorial.Model.Entities;
using Domain.UserHistorial.Model.Queries;
using Domain.UserHistorial.Model.Commands;
using Domain.UserHistorial.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.UserHistorial.Controllers;
using Presentation.UserHistorial.Resources;


namespace PresentationTest.UserHistorial;

public class HistoryControllerTest
{
    private readonly Mock<IHistoryQueryService> _mockQueryService;
    private readonly Mock<IHistoryCommandService> _mockCommandService;
    private readonly HistoryController _controller;

    public HistoryControllerTest()
    {
        _mockQueryService = new Mock<IHistoryQueryService>();
        _mockCommandService = new Mock<IHistoryCommandService>();
        _controller = new HistoryController(_mockQueryService.Object, _mockCommandService.Object);
    }

    [Fact]
    public async Task GetAll_ShouldReturnOk_WhenDataExists()
    {
        // Arrange
        var histories = new List<HistoryEntity>
        {
            new HistoryEntity { Id = 1 },
            new HistoryEntity { Id = 2 }
        };
        _mockQueryService.Setup(service => service.Handle(It.IsAny<GetAllHistoryQuery>())).ReturnsAsync(histories);

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<HistoryResource>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
    }

    [Fact]
    public async Task GetAll_ShouldReturnNotFound_WhenNoDataExists()
    {
        // Arrange
        _mockQueryService.Setup(service => service.Handle(It.IsAny<GetAllHistoryQuery>())).ReturnsAsync((IEnumerable<HistoryEntity>)null);

        // Act
        var result = await _controller.GetAll();

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
    

    [Fact]
    public async Task GetById_ShouldReturnNotFound_WhenIdIsInvalid()
    {
        // Arrange
        _mockQueryService.Setup(service => service.Handle(It.IsAny<GetHistoryByIdQuery>())).ReturnsAsync((HistoryEntity)null);

        // Act
        var result = await _controller.GetById(1);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Create_ShouldReturnCreated_WhenDataIsValid()
    {
        // Arrange
        var createResource = new CreateHistoryResource(
            Guid.NewGuid(), // ClientId
            Guid.NewGuid(), // ScooterId
            DateTime.UtcNow, // StartDate
            DateTime.UtcNow.AddHours(1), // EndDate
            10.0m, // Price
            60 // Time
        );
        var createdId = 1;
        _mockCommandService.Setup(service => service.Handle(It.IsAny<CreateHistoryCommand>())).ReturnsAsync(createdId);

        // Act
        var result = await _controller.Create(createResource);

        // Assert
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(nameof(_controller.GetById), createdResult.ActionName);
        Assert.Equal(createdId, Convert.ToInt32(createdResult.RouteValues["id"]));
    }

    [Fact]
    public async Task Create_ShouldReturnBadRequest_WhenDataIsInvalid()
    {
        // Arrange
        _controller.ModelState.AddModelError("error", "some error");

        // Act
        var result = await _controller.Create(new CreateHistoryResource(
            Guid.NewGuid(), // ClientId
            Guid.NewGuid(), // ScooterId
            DateTime.UtcNow, // StartDate
            DateTime.UtcNow.AddHours(1), // EndDate
            10.0m, // Price
            60 // Time
        ));

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
    
    [Fact]
    public async Task Delete_ShouldReturnNoContent_WhenIdIsValid()
    {
        // Arrange
        _mockCommandService.Setup(service => service.Handle(It.IsAny<DeleteHistoryCommand>())).ReturnsAsync(true);

        // Act
        var result = await _controller.Delete(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Delete_ShouldReturnNotFound_WhenIdIsInvalid()
    {
        // Arrange
        _mockCommandService.Setup(service => service.Handle(It.IsAny<DeleteHistoryCommand>())).ReturnsAsync(false);

        // Act
        var result = await _controller.Delete(1);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}