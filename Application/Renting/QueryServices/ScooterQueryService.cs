using Domain.Renting.Model.Entities;
using Domain.Renting.Model.Queries;
using Domain.Renting.Repositories;
using Domain.Renting.Services;

namespace Application.Renting.QueryServices;

public class ScooterQueryService(IScooterRepository scooterRepository) : IScooterQueryService
{
    public async Task<ScooterEntity?> Handle(GetScooterByIdQuery query)
    {
        return await scooterRepository.GetByIdAsync(query.Id);
    }

    public async Task<IEnumerable<ScooterEntity>> Handle(GetAllScootersQuery query)
    {
        return await scooterRepository.GetAllAsync();
    }
}