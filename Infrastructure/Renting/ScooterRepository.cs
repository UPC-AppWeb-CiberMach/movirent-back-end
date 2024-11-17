using Domain.Renting.Model.Entities;
using Domain.Renting.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;

namespace Infrastructure.Renting;
/// <summary>
/// Repositorio de scooters
/// </summary>
public class ScooterRepository(AppDbContext context) : BaseRepository<ScooterEntity>(context), IScooterRepository
{
    
}