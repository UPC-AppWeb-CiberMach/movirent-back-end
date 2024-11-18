using System.Data;
using System.Threading.Tasks;
using Application.UserHistorial.CommandServices;
using Domain.UserHistorial.Model.Commands;
using Domain.UserHistorial.Model.Entities;
using Domain.UserHistorial.Repositories;
using Domain.Shared;
using Moq;
using Xunit;
using FluentAssertions;


namespace ApplicationTest.UserHistorial.CommandServices;

public class HistoryCommandServiceTest
{
    private readonly Mock<IHistoryRepository> _mockRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly HistoryCommandService _service;

    public HistoryCommandServiceTest()
    {
        _mockRepository = new Mock<IHistoryRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _service = new HistoryCommandService(_mockRepository.Object, _mockUnitOfWork.Object);
    }

    [Fact]
    public async Task Handle_CreateHistoryCommand_ShouldThrowException_WhenClientDoesNotExist()
    {
        // Arrange
        var command = new CreateHistoryCommand(
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateTime.Now,
            DateTime.Now.AddHours(1),
            10.0m,
            60
        );

        _mockRepository.Setup(repo => repo.ExistByClientIdAsync(command.ClientId))
            .ReturnsAsync(false); // Simula que el cliente no existe

        // Act
        Func<Task> act = async () => await _service.Handle(command);

        // Assert
        await act.Should().ThrowAsync<DuplicateNameException>()
            .WithMessage("User does not exist");
    }

    [Fact]
    public async Task Handle_CreateHistoryCommand_ShouldReturnId_WhenDataIsValid()
    {
        // Arrange
        var command = new CreateHistoryCommand(
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateTime.Now,
            DateTime.Now.AddHours(1),
            10.0m,
            60
        );

        _mockRepository.Setup(repo => repo.ExistByClientIdAsync(command.ClientId))
            .ReturnsAsync(true);
        _mockRepository.Setup(repo => repo.ExistByScooterIdAsync(command.ScooterId))
            .ReturnsAsync(true);
        _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<HistoryEntity>()))
            .Callback<HistoryEntity>(entity => entity.Id = 123); // Simula que se le asigna un ID al guardar

        // Act
        var result = await _service.Handle(command);

        // Assert
        result.Should().Be(123);
        _mockRepository.Verify(repo => repo.AddAsync(It.IsAny<HistoryEntity>()), Times.Once);
        _mockUnitOfWork.Verify(uow => uow.CompleteAsync(), Times.Once);
    }
}