using Domain.IAM.Model.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.IAM.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Application.IAM.CommandServices;

public class TokenService: ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public  string GenerateToken(UserProfile user)
    {

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Auth:Secretkey"]));
    
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Rol)
            }),
            Expires = DateTime.UtcNow.AddHours(4),
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public UserProfile? ValidateToken(string token)
    {
        if (string.IsNullOrEmpty(token))
            return null;

        var tokenHandler = new JsonWebTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Auth:Secretkey"]);

        var tokenValidationResult = tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        });

        if (!tokenValidationResult.IsValid)
            return null;

        var jwtToken = (JsonWebToken)tokenValidationResult.SecurityToken;
        var userId = Guid.Parse(jwtToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value);
        var email = jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value;
        var rol = jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role)?.Value;

        var user = new UserProfile
        {
            Id = userId,
            Email = email,
            Rol = rol
        };

        return user;
    }
    
}
