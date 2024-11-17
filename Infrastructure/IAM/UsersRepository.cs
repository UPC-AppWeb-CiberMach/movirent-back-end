using Domain.IAM.Model.Entities;
using Domain.IAM.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;

namespace Infrastructure.IAM;

/// <summary>
/// Repositorio de usuarios
/// </summary>
public class UsersRepository(AppDbContext context) : BaseRepository<UserProfile>(context), IUsersRepository
{
    
}