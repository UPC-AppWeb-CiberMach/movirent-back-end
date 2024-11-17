using Domain.IAM.Model.Entities;
using Domain.Shared;

namespace Domain.IAM.Repositories;

public interface IUsersRepository : IBaseRepository<UserProfile>
{
    Task<UserProfile> GetByEmailAsync(string email);
    Task<UserProfile> GetByDniAsync(string dni);
    Task<UserProfile> GetByPhoneAsync(string phone);
}