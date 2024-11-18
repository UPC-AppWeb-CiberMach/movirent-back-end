using Domain.IAM.Model.Entities;

namespace Domain.IAM.Services;

public interface ITokenService
{
    string GenerateToken(UserProfile user);
    UserProfile? ValidateToken(string token);
}