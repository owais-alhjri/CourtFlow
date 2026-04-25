namespace CourtFlow.Domain.Entities;

public class Waitlist
{
    public int Id { get; private set; }
    public int CourtId { get; private set; }
    public int UserId { get; private set; }

    public DateTime RequestedStartTime { get; private set; }
    public DateTime RequestedEndTime { get; private set; }
    public DateTime JoinedAt { get; private set; }

    [Obsolete("For EF core only.", error: true)]
    protected Waitlist()
    {
    }

    public User User { get; private set; }
    public Court Court { get; private set; }

    public Waitlist(Court court, User user, DateTime requestedStartTime, DateTime requestedEndTime, DateTime joinedAt)
    {
        CourtId = court.Id;
        UserId = user.Id;
        RequestedStartTime = requestedStartTime;
        RequestedEndTime = requestedEndTime;
        JoinedAt = joinedAt;
    }
}