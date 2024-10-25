using Domain.Scooter.Model.Queries;
using Domain.Scooter.Model.Entities;
namespace Domain.Scooter.Services;

public interface IScooterQueryService
{
    Task<IEnumerable<Model.Entities.Scooter>?> Handle(GetAllScootersQuery query);
    Task<Model.Entities.Scooter?> Handle(GetScooterByIdQuery query);
}