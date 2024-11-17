using System.Collections.Generic;
using System.Threading.Tasks;
using Application.UserHistorial.QueryServices;
using Domain.UserHistorial.Model.Entities;
using Domain.UserHistorial.Model.Queries;
using Domain.UserHistorial.Repositories;
using Moq;
using Xunit;

namespace ApplicationTest.UserHistorial.QueryServices;

public class HistoryQueryServiceTest
{
    private readonly Mock<IHistoryRepository> _mockRepository;
    private readonly HistoryQueryService _service;

    public HistoryQueryServiceTest()
    {
        _mockRepository = new Mock<IHistoryRepository>();
        _service = new HistoryQueryService(_mockRepository.Object);
    }

    [Fact]
    public async Task Handle_GetAllHistoryQuery_ShouldReturnAllHistories()
    {
        // Arrange
        var histories = new List<HistoryEntity>
        {
            new HistoryEntity { Id = 1, ClientId = Guid.NewGuid(), ScooterId = Guid.NewGuid(), StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddHours(1), Price = 10.0m, Time = 60 },
            new HistoryEntity { Id = 2, ClientId = Guid.NewGuid(), ScooterId = Guid.NewGuid(), StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddHours(2), Price = 20.0m, Time = 120 }
        };

        _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(histories);

        // Act
        var result = await _service.Handle(new GetAllHistoryQuery());

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task Handle_GetHistoryByIdQuery_ShouldReturnHistory_WhenIdIsValid()
    {
        // Arrange
        var history = new HistoryEntity { Id = 1, ClientId = Guid.NewGuid(), ScooterId = Guid.NewGuid(), StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddHours(1), Price = 10.0m, Time = 60 };

        _mockRepository.Setup(repo => repo.GetByLongIdAsync(1)).ReturnsAsync(history);

        // Act
        var result = await _service.Handle(new GetHistoryByIdQuery(1));

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }

    [Fact]
    public async Task Handle_GetHistoryByIdQuery_ShouldReturnNull_WhenIdIsInvalid()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.GetByLongIdAsync(1)).ReturnsAsync((HistoryEntity)null);

        // Act
        var result = await _service.Handle(new GetHistoryByIdQuery(1));

        // Assert
        Assert.Null(result);
    }
}