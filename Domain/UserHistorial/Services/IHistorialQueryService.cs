using Domain.UserHistorial.Model.Entities;
using Domain.UserHistorial.Model.Queries;

namespace Domain.UserHistorial.Services;

public interface IHistorialQueryService
{
    Task<IEnumerable<HistorialEntity>?> Handle(GetAllHistorialsQuery query);
    Task<HistorialEntity?> Handle(GetHistorialByIdQuery query);
}