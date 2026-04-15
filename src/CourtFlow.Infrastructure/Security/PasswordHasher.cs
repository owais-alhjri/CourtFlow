using CourtFlow.Domain.Services;
using CourtFlow.Domain.ValueObjects;

namespace CourtFlow.Infrastructure.Security;

public class PasswordHasher : IPasswordHasher
{
    public PasswordHash Hash(string password)
    {
        var hash = BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
        return new PasswordHash(hash);
    } 

    public bool Verify(string password, string hash)
        => BCrypt.Net.BCrypt.Verify(password, hash);
}