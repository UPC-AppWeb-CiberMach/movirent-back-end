using Domain.IAM.Model.Entities;
using Domain.IAM.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.IAM;
/*
 * public interface IUsersRepository : IBaseRepository<UserProfile>
{
    Task<UserProfile> GetByEmailAsync(string email);
    Task<UserProfile> GetByDniAsync(string dni);
    Task<UserProfile> GetByPhoneAsync(string phone);
}
 */
public class UsersRepository(AppDbContext context) : BaseRepository<UserProfile>(context), IUsersRepository
{
    public async Task<UserProfile> GetByEmailAsync(string email)
    {
        return await context.Set<UserProfile>().FirstOrDefaultAsync(x => x.Email == email);
    }
    
    public async Task<UserProfile> GetByDniAsync(string dni)
    {
        return await context.Set<UserProfile>().FirstOrDefaultAsync(x => x.Dni == dni);
    }
    
    public async Task<UserProfile> GetByPhoneAsync(string phone)
    {
        return await context.Set<UserProfile>().FirstOrDefaultAsync(x => x.Phone == phone);
    }
}