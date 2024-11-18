using Domain.UserHistorial.Model.Entities;
using Domain.UserHistorial.Model.Queries;
using Domain.UserHistorial.Repositories;
using Domain.UserHistorial.Services;

namespace Application.UserHistorial.QueryServices;

/// <summary>
/// Servicio de consultas de historiales
/// </summary>

public class HistoryQueryService(IHistoryRepository repository) : IHistoryQueryService
{
    
    public async Task<IEnumerable<HistoryEntity>?> Handle(GetAllHistoryQuery query)
    {
        return await repository.GetAllAsync();
    }

    public async Task<HistoryEntity?> Handle(GetHistoryByIdQuery query)
    {
        return await repository.GetByLongIdAsync(query.Id);
    }
}