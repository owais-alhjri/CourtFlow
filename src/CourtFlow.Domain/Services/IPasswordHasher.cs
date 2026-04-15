using CourtFlow.Domain.ValueObjects;

namespace CourtFlow.Domain.Services;

public interface IPasswordHasher
{
    PasswordHash Hash(string password);
    bool Verify(string password, string hash);
}