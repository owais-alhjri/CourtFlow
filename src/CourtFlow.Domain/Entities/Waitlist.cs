using CourtFlow.Domain.ValueObjects;

namespace CourtFlow.Domain.Entities;

public class Waitlist
{
    public int Id { get; private set; }
    public int CourtId { get; private set; }
    public int UserId { get; private set; }
    public TimeRule RequestedTime { get; private set; }
    public DateTime JoinedAt { get; private set; }


    [Obsolete("For EF core only.", error: true)]
    protected Waitlist()
    {
    }

    public User User { get; private set; }
    public Court Court { get; private set; }

    public Waitlist(Court court, User user, TimeRule requestedTime)
    {
        ArgumentNullException.ThrowIfNull(court);
        ArgumentNullException.ThrowIfNull(user);
        ArgumentNullException.ThrowIfNull(requestedTime);

        User = user;
        Court = court;
        CourtId = court.Id;
        UserId = user.Id;
        RequestedTime = requestedTime;
        JoinedAt = DateTime.UtcNow;
    }

    
}