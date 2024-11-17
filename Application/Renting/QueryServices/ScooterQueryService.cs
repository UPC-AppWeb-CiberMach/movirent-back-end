using Domain.Renting.Model.Entities;
using Domain.Renting.Model.Queries;
using Domain.Renting.Repositories;
using Domain.Renting.Services;

namespace Application.Renting.QueryServices;

/// <summary>
/// Servicio de consultas de scooters
/// </summary>
public class ScooterQueryService : IScooterQueryService
{
    private readonly IScooterRepository _scooterRepository;

    public ScooterQueryService(IScooterRepository scooterRepository)
    {
        _scooterRepository = scooterRepository;
    }
    public async Task<ScooterEntity?> Handle(GetScooterByIdQuery query)
    {
        return await _scooterRepository.GetByIdAsync(query.Id);
    }

    public async Task<IEnumerable<ScooterEntity>> Handle(GetAllScootersQuery query)
    {
        return await _scooterRepository.GetAllAsync();
    }
}