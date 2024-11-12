using Domain.UserHistorial.Model.Entities;
using Domain.Shared;

namespace Domain.UserHistorial.Repositories;

public interface IHistoryRepository : IBaseRepository<HistoryEntity>
{
    Task<bool> ExistByClientIdAsync(Guid clientId);
    Task<bool> ExistByScooterIdAsync(Guid scooterId);
}