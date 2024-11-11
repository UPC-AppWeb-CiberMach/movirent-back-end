using Domain.Renting.Model.Entities;
using Domain.Renting.Model.Queries;

namespace Domain.Renting.Services;

public interface IScooterQueryService
{
    Task<IEnumerable<ScooterEntity>> Handle(GetAllScootersQuery query);
    Task<ScooterEntity?> Handle(GetScooterByIdQuery query);
}