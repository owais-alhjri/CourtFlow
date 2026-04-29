using CourtFlow.Domain.Enums;
using CourtFlow.Domain.ValueObjects;

namespace CourtFlow.Domain.Entities;

public class Booking
{
    public int Id { get; private set; }
    public int CourtId { get; private set; }
    public int UserId { get; private set; }

    public TimeRule Time { get; private set; }
    public Status Status { get; private set; }
    public Money TotalPrice { get; private set; }
    public bool IsLateCancellation { get; private set; }
    public DateTime CreatedAt { get; private set; }


    [Obsolete("For EF core only.", error: true)]
    protected Booking()
    {
    }

    public User User { get; private set; }
    public Court Court { get; private set; }

    public Booking(TimeRule time, Money price, User user, Court court)
    {
        ArgumentNullException.ThrowIfNull(time);
        ArgumentNullException.ThrowIfNull(user);
        ArgumentNullException.ThrowIfNull(court);
        ArgumentNullException.ThrowIfNull(price);

        User = user;
        Court = court;
        UserId = user.Id;
        CourtId = court.Id;
        Time = time;
        TotalPrice = price;
        CreatedAt = DateTime.UtcNow;
        IsLateCancellation = false;
        Status = Status.Pending;
    }
}