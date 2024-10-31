using Domain.Historial.Model.Entities;
using Domain.Historial.Model.Queries;
using Domain.Historial.Repositories;
using Domain.Historial.Services;

namespace Application.Historial.QueryServices;

public class HistorialQueryService : IHistorialQueryService
{
    private readonly IHistorialRepository _repository;

    public HistorialQueryService(IHistorialRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<HistorialEntity>?> Handle(GetAllHistorialsQuery query)
    {
        return await _repository.GetAllAsync();
    }

    public async Task<HistorialEntity?> Handle(GetHistorialByIdQuery query)
    {
        return await _repository.GetByIdAsync(query.Id);
    }
}