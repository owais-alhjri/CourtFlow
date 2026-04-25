using CourtFlow.Domain.Enums;

namespace CourtFlow.Domain.Entities;

public class Booking
{
    public int Id { get; private set; }
    public int CourtId { get; private set; }
    public int UserId { get; private set; }

    // TODO: Create a ValueObject for Start and End time
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    public Status Status { get; private set; }
    public decimal TotalPrice { get; private set; }
    public bool IsLateCancellation { get; private set; }
    public DateTime CreatedAt { get; private set; }


    [Obsolete("For EF core only.", error: true)]
    protected Booking()
    {
    }

    public User User { get; private set; }
    public Court Court { get; private set; }

    public Booking(DateTime startTime, DateTime endTime, int price, User user, Court court, Status status)
    {
        UserId = user.Id;
        CourtId = court.Id;
        StartTime = startTime;
        EndTime = endTime;
        TotalPrice = price;
        CreatedAt = DateTime.UtcNow;
        IsLateCancellation = false;
        Status = status;
    }
}