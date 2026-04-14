using CourtFlow.Domain.Enums;

namespace CourtFlow.Domain.Entities;

public class Booking
{
    public Guid Id { get; private set; }
    public Guid CourtId { get; private set; }
    public Guid UserId { get; private set; }

    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    public Status Status { get; private set; }
    public int TotalPrice { get; private set; }
    public DateTime CreatedAt { get; private set; }


    protected Booking()
    {
    }

    public User User { get; private set; }
    public Court Court { get; private set; }

    public Booking(DateTime startTime, DateTime endTime, int price, User user, Court court)
    {
        Id = Guid.NewGuid();
        UserId = user.Id;
        CourtId = court.Id;
        StartTime = startTime;
        EndTime = endTime;
        TotalPrice = price;
        CreatedAt = DateTime.Now;
    }
}