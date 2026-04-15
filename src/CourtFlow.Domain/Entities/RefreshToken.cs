namespace CourtFlow.Domain.Entities;

public class RefreshToken
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Token { get; set; }
    public DateTime ExpiresAt { get; set; }
    public bool IsRevoked { get; set; }
    public DateTime CreatedAt { get; set; }

    protected RefreshToken()
    {
    }

    public User User { get; private set; }

    public RefreshToken(User user, string token, DateTime expiresAt, bool isRevoked)
    {
        UserId = user.Id;
        Token = token;
        ExpiresAt = expiresAt;
        IsRevoked = isRevoked;
        CreatedAt = DateTime.UtcNow;
    }
}