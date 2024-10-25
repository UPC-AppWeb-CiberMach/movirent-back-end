using Domain.Scooter.Model.Commands;
using Domain.Scooter.Repositories;
using Domain.Scooter.Services;
using Domain.Scooter.Model.Entities;
using Domain.Shared;

namespace Application.Scooter.CommandServices;

public class ScooterCommandService : IScooterCommandService
{
    private readonly IScooterRepository _scooterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ScooterCommandService(IScooterRepository scooterRepository, IUnitOfWork unitOfWork)
    {
        _scooterRepository = scooterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateScooterCommand command)
    { 
        var scooter = new Domain.Scooter.Model.Entities.Scooter
        {
            Name = command.Name,
            Brand = command.Brand,
            Model = command.Model,
            Image = command.Image,
            PricePerHour = command.PricePerHour,
            District = command.District,
            Phone = command.Phone
        };
        
        await _scooterRepository.AddAsync(scooter);
        await _unitOfWork.CompleteAsync();
        return scooter.Id;
    }
}