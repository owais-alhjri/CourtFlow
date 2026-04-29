using CourtFlow.Domain.ValueObjects;

namespace CourtFlow.Domain.Entities;

public class MaintenanceWindow
{
    public int Id { get; private set; }
    public int CourtId { get; private set; }
    public TimeRule Window { get; private set; }
    public string Reason { get; private set; }


    [Obsolete("For EF core only.", error: true)]
    protected MaintenanceWindow()
    {
    }
    public Court Court { get; private set; }

    public MaintenanceWindow(Court court, TimeRule window, string reason)
    {
        ValidateReason(reason);
        ArgumentNullException.ThrowIfNull(court);
        ArgumentNullException.ThrowIfNull(window);
        Court = court;
        CourtId = court.Id;
        Window = window;
        Reason = reason;
    }

    private static void ValidateReason(string reason)
    {
        if (string.IsNullOrWhiteSpace(reason))
            throw new ArgumentException("Reason is required.");

        if (reason.Length < 3 || reason.Length > 100)
            throw new ArgumentException("Reason must be between 3 and 100 characters.");
    }   
}