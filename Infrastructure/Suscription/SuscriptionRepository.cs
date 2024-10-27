using Domain.Suscription.Model.Entities;
using Domain.Suscription.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;

namespace Infrastructure.Suscription;

public class SuscriptionRepository(AppDbContext context) : BaseRepository<SuscriptionEntity>(context), ISuscriptionRepository
{
    
}