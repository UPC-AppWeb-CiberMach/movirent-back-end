using Domain.Shared;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Shared.Persistence.EFC.Repositories;

public class BaseRepository<TEntity>(AppDbContext context) : IBaseRepository<TEntity> where TEntity : class
{
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("El ID debe ser un número positivo.");
        }

        return await context.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");
        }

        await context.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public async Task UpdateAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");
        }

        context.Set<TEntity>().Update(entity);
    }

    public async Task RemoveAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");
        }

        context.Set<TEntity>().Remove(entity);
    }

    public void Update(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");
        }

        context.Set<TEntity>().Update(entity);
    }

    public void Delete(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");
        }

        context.Set<TEntity>().Remove(entity);
    }
}