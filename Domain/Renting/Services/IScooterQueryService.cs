using Domain.Renting.Model.Entities;
using Domain.Renting.Model.Queries;

namespace Domain.Renting.Services;

public interface IScooterQueryService
{
    Task<IEnumerable<ScooterVehicle>> Handle(GetAllScootersQuery query);
    Task<ScooterVehicle?> Handle(GetScooterByIdQuery query);
}