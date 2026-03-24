using System.Security.Claims;
using System.Text;
using CourtFlow.Application.Interfaces;
using CourtFlow.Domain.Auth;
using CourtFlow.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace CourtFlow.Infrastructure.Services;

public class TokenService(IOptions<JwtOptions> jwtOptions) : ITokenService
{
    private readonly JsonWebTokenHandler _handler = new();

    public string GenerateToken(JwtUserClaims user)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtOptions.Value.Secret));
        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Identifier),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(jwtOptions.Value.ExpirationMinutes),
            Issuer = jwtOptions.Value.Issuer,
            Audience = jwtOptions.Value.Audience,
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        };
        return _handler.CreateToken(descriptor);
    }
}