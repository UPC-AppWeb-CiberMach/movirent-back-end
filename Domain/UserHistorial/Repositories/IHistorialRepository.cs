using Domain.Historial.Model.Entities;
using Domain.Shared;

namespace Domain.Historial.Repositories;

public interface IHistorialRepository : IBaseRepository<HistorialEntity>
{
    Task<HistorialEntity?> CheckScooterAvailableAsync(int id);
    Task<HistorialEntity?> CheckUserActiveHistorialAsync(int id);
}