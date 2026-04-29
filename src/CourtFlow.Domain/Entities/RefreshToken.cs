namespace CourtFlow.Domain.Entities;

public class RefreshToken
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public string Token { get; private set; }
    public DateTime ExpiresAt { get; private set; }
    public bool IsRevoked { get; private set; }
    public DateTime CreatedAt { get; private set; }


    [Obsolete("For EF core only.", error: true)]
    protected RefreshToken()
    {
    }

    public User User { get; private set; }

    public RefreshToken(User user, string token)
    {
        ArgumentNullException.ThrowIfNull(user);
        ArgumentNullException.ThrowIfNull(token);
        User = user;
        UserId = user.Id;
        Token = token;
        ExpiresAt = DateTime.UtcNow.AddDays(7);
        IsRevoked = false;
        CreatedAt = DateTime.UtcNow;
    }
}