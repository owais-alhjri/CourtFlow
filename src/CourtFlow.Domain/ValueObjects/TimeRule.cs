namespace CourtFlow.Domain.ValueObjects;

public record TimeRule
{
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }

    private TimeRule() { }

    public TimeRule(DateTime start, DateTime end)
    {
        if (end <= start)
            throw new ArgumentException("End time must be after start time.");

        Start = start;
        End = end;
    }

    public bool OverlapsWith(TimeRule other) =>
        Start < other.End && End > other.Start;

    // this is how would I use OverlapsWith
    /*
       var requested = new TimeRule(startTime, endTime);
       
       bool courtIsAvailable = existingBookings
           .All(b => !b.TimeRule.OverlapsWith(requested));
     */


}