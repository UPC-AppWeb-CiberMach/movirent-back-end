using Domain.IAM.Model.Entities;
using Domain.IAM.Model.Queries;
using Domain.IAM.Repositories;
using Domain.IAM.Services;

namespace Application.IAM.QueryServices;

/// <summary>
/// Servicio de consultas de usuario
/// </summary>
public class UserQueryService : IUserQueryService
{
    private readonly IUsersRepository _usersRepository;
    
    public UserQueryService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }
    
    public async Task<IEnumerable<UserProfile>> Handle(GetAllUsersQuery query)
    {
        return await _usersRepository.GetAllAsync();
    }
    
    public async Task<UserProfile?> Handle(GetUsersByIdQuery query)
    {
        return await _usersRepository.GetByIdAsync(query.id);
    }
}