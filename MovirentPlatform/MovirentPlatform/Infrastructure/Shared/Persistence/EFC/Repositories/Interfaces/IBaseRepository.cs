namespace Infrastructure.Shared.Persistence.EFC.Repositories.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
  Task<IEnumerable<TEntity>> GetAllAsync();
  Task<TEntity?> GetByIdAsync(int id);
  Task<TEntity> AddAsync(TEntity entity);
}