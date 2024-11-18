using Domain.Renting.Model.Commands;
using Domain.Renting.Model.Entities;
using Domain.Renting.Repositories;
using Domain.Renting.Services;
using Domain.Scooter.Model.Commands;
using Domain.Shared;

namespace Application.Renting.CommandServices;

/// <summary>
/// Servicio de comandos de scooters
/// </summary>

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