using Domain.UserHistorial.Model.Entities;
using Domain.UserHistorial.Model.Queries;

namespace Domain.UserHistorial.Services;

public interface IHistoryQueryService
{
    Task<IEnumerable<HistoryEntity>?> Handle(GetAllHistoryQuery query);
    Task<HistoryEntity?> Handle(GetHistoryByIdQuery query);
}