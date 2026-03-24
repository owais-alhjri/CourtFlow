using CourtFlow.Domain.Enums;

namespace CourtFlow.Domain.Auth;

public class JwtUserClaims
{
    public Guid Id { get; set; }
    public string Identifier { get; set; } = null!;
    public UserRole Role { get; set; } 
}