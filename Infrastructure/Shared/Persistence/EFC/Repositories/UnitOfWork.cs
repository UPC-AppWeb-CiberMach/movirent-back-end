using Infrastructure.Shared.Persistence.EFC.Configuration;
using Domain.Shared;
namespace Infrastructure.Shared.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context): IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}