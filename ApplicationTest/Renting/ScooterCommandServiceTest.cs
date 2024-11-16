using Application.Renting.CommandServices;
using Domain.Renting.Model.Commands;
using Domain.Renting.Repositories;
using Domain.Scooter.Model.Commands;
using Domain.Shared;
using Moq;

namespace ApplicationTest.Renting;

public class ScooterCommandServiceTest
{
    /*
     * using Domain.Renting.Model.Commands;
using Domain.Renting.Model.Entities;
using Domain.Renting.Repositories;
using Domain.Renting.Services;
using Domain.Scooter.Model.Commands;
using Domain.Shared;

namespace Application.Renting.CommandServices;

public class ScooterCommandService : IScooterCommandService
{
    private readonly IScooterRepository _scooterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ScooterCommandService(IScooterRepository scooterRepository, IUnitOfWork unitOfWork)
    {
        _scooterRepository = scooterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateScooterCommand command)
    {
        var scooter = new ScooterEntity(command);
        
        await _scooterRepository.AddAsync(scooter);
        await _unitOfWork.CompleteAsync();
        return scooter.Id;
    }

    public async Task<bool> Handle(UpdateScooterCommand command)
    {
        var scooter = await _scooterRepository.GetByIdAsync(command.Id);
        if (scooter == null)
        {
            throw new Exception("Renting not found");
        }
        _scooterRepository.Update(scooter);
        scooter.UpdateScooterInfo(command);
        await _unitOfWork.CompleteAsync();
        return true;

    }

    public async Task<bool> Handle(DeleteScooterCommand command)
    {
        var scooter = await _scooterRepository.GetByIdAsync(command.Id);
        if (scooter == null)
        {
            throw new Exception("Renting not found");
        }
        _scooterRepository.Delete(scooter);
        await _unitOfWork.CompleteAsync();
        return true;
    }
}
     */
    
    // Deseo que me hagas los Test
    // para el método Handle(CreateScooterCommand command)
    // para el método Handle(UpdateScooterCommand command)
    // para el método Handle(DeleteScooterCommand command)
    // de la clase ScooterCommandService
    // con los siguientes casos de prueba:


    [Fact]
    public void CreateScooterTest()
    {
        // Arrange
        var scooterRepository = new Mock<IScooterRepository>();
        var unitOfWork = new Mock<IUnitOfWork>();
        var scooterCommandService = new ScooterCommandService(scooterRepository.Object, unitOfWork.Object);
        var command = new CreateScooterCommand(
            "Scooter 1",
            "Scooter 1",
            "Scooter 1",
            "Scooter 1",
            120,
            "Los Olivos",
            "987654321");

        // Act
        var result = scooterCommandService.Handle(command);

        // Assert
        Assert.NotNull(result);
    }
    
    [Fact]
    public void UpdateScooterTest()
    {
        
        //public record UpdateScooterCommand(int Id, string Name, string Brand, string Model, string Image, double PricePerHour, string District, string Phone);public record UpdateScooterCommand(int Id, string Name, string Brand, string Model, string Image, double PricePerHour, string District, string Phone);
        // Arrange
        var scooterRepository = new Mock<IScooterRepository>();
        var unitOfWork = new Mock<IUnitOfWork>();
        var scooterCommandService = new ScooterCommandService(scooterRepository.Object, unitOfWork.Object);
        var command = new UpdateScooterCommand(
            1,
            "Scooter 1",
            "Scooter 1",
            "Scooter 1",
            "Scooter 1",
            120,
            "Los Olivos",
            "987654321");

        // Act
        var result = scooterCommandService.Handle(command);

        // Assert
        Assert.NotNull(result);
    }
    
    [Fact]
    public void DeleteScooterTest()
    {
        // Arrange
        var scooterRepository = new Mock<IScooterRepository>();
        var unitOfWork = new Mock<IUnitOfWork>();
        var scooterCommandService = new ScooterCommandService(scooterRepository.Object, unitOfWork.Object);
        var command = new DeleteScooterCommand(1);

        // Act
        var result = scooterCommandService.Handle(command);

        // Assert
        Assert.NotNull(result);
    }
}