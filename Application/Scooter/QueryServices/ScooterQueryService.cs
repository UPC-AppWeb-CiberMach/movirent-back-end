using Domain.Scooter.Model.Queries;
using Domain.Scooter.Repositories;
using Domain.Scooter.Services;
using Domain.Scooter.Model.Entities;

namespace Application.Scooter.QueryServices;

public class ScooterQueryService : IScooterQueryService
{
    private readonly IScooterRepository _scooterRepository;

    public ScooterQueryService(IScooterRepository scooterRepository)
    {
        _scooterRepository = scooterRepository;
    }

    public async Task<IEnumerable<Scooter>?> Handle(GetAllScootersQuery query)
    {
        return await _scooterRepository.ListAsync();
    }

    public Task<List<Scooter>?> Handle(GetAllScootersQuery query)
    {
        throw new NotImplementedException();
    }
}