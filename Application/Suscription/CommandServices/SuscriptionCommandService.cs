using Domain.Suscription.Model.Commands;
using Domain.Suscription.Model.Entities;
using Domain.Suscription.Repositories;
using Domain.Suscription.Services;
using Domain.Suscription.Model.Commands;
using Infrastructure.Shared.Persistence.EFC.Repositories.Interfaces;

namespace Application.Suscription.CommandServices;

public class SuscriptionCommandService : ISuscriptionCommandService
{
    private readonly ISuscriptionRepository _suscriptionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SuscriptionCommandService(ISuscriptionRepository suscriptionRepository, IUnitOfWork unitOfWork)
    {
        _suscriptionRepository = suscriptionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateSuscriptionCommand command)
    {
        var suscription = new SuscriptionEntity(command);
        
        await _suscriptionRepository.AddAsync(suscription);
        await _unitOfWork.CompleteAsync();
        return suscription.Id;
    }
}