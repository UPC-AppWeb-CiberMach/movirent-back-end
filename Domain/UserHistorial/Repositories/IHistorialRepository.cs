using Domain.UserHistorial.Model.Entities;
using Domain.Shared;

namespace Domain.UserHistorial.Repositories;

public interface IHistorialRepository : IBaseRepository<HistorialEntity>
{
    Task<HistorialEntity?> CheckScooterAvailableAsync(int id);
    Task<HistorialEntity?> CheckUserActiveHistorialAsync(int id);
}