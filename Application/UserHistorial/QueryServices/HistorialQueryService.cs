using Domain.UserHistorial.Model.Entities;
using Domain.UserHistorial.Model.Queries;
using Domain.UserHistorial.Repositories;
using Domain.UserHistorial.Services;

namespace Application.UserHistorial.QueryServices;

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