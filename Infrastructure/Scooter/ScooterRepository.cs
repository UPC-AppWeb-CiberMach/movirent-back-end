using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;

namespace Infrastructure.Scooter;

public class ScooterRepository(AppDbContext context): BaseRepository<Scooter>(context), IScooterRepository
{
    
}