namespace CourtFlow.Domain.ValueObjects;

public record HourRange
{
    public int Start { get; }
    public int End { get; }

    public HourRange(int start, int end)
    {
        if (start < 0 || start > 23)
            throw new ArgumentException("Start hour must be between 0 and 23.");
        if(end < 0 || end > 23)
            throw new ArgumentException("End hour must be between 0 and 23.");

        if (end <= start)
            throw new ArgumentException("End hour must be after start hour.");

        Start = start;
        End = end;
    }
    private HourRange() { } //EF Core

}