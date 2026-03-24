using CourtFlow.Domain.Auth;

namespace CourtFlow.Application.Interfaces;

public interface ITokenService
{
    string GenerateToken(JwtUserClaims user);
}