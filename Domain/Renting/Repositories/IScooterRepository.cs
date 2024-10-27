using Domain.Renting.Model.Entities;
using Domain.Shared;
using Infrastructure.Shared.Persistence.EFC.Repositories.Interfaces;

namespace Domain.Renting.Repositories;

public interface IScooterRepository : IBaseRepository<ScooterVehicle>
{
  
}