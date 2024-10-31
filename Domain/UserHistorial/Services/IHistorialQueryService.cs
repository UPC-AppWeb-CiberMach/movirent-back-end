using Domain.Historial.Model.Entities;
using Domain.Historial.Model.Queries;

namespace Domain.Historial.Services;

public interface IHistorialQueryService
{
    Task<IEnumerable<HistorialEntity>?> Handle(GetAllHistorialsQuery query);
    Task<HistorialEntity?> Handle(GetHistorialByIdQuery query);
}