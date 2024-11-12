using Domain.Shared;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Shared.Persistence.EFC.Repositories;

public class BaseRepository<TEntity>(AppDbContext context): IBaseRepository<TEntity> where TEntity : class
{
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity?> GetByLongIdAsync(long id)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await context.Set<TEntity>().AddAsync(entity);
        return entity;
    }
    
    public Task UpdateAsync(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(TEntity entity)
    {
        context.Set<TEntity>().Remove(entity);
        return Task.CompletedTask;
    }
    

    public void Update(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
    }

    public void Delete(TEntity entity)
    {
        context.Set<TEntity>().Remove(entity);
    }
}