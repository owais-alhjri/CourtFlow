namespace CourtFlow.Domain.Entities;

public class MaintenanceWindow
{
    public int Id { get; private set; }
    public int CourtId { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EntTime { get; private set; }
    public string Reason { get; private set; }


    [Obsolete("For EF core only.", error: true)]
    protected MaintenanceWindow()
    {
    }
    public Court Court { get; private set; }

    public MaintenanceWindow(Court court, DateTime startTime, DateTime entTime, string reason)
    {
        CourtId = court.Id;
        StartTime = startTime;
        EntTime = entTime;
        Reason = reason;
    }
}