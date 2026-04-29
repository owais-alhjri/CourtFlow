using CourtFlow.Domain.ValueObjects;

namespace CourtFlow.Domain.Entities;

public class PricingRule
{
    public int Id { get; private set; }
    public int CourtId { get; private set; }
    public DayOfWeek DayOfWeek { get; private set; }
    public HourRange HourRange { get; private set; }
    public Money PricePerHour { get; private set; }


    [Obsolete("For EF core only.", error: true)]
    protected PricingRule()
    {
    }

    public Court Court { get; private set; }

    public PricingRule(Court court, DayOfWeek dayOfWeek, HourRange hourRange, Money pricePerHour)
    {
        ArgumentNullException.ThrowIfNull(court);
        ArgumentNullException.ThrowIfNull(hourRange);
        ArgumentNullException.ThrowIfNull(pricePerHour);
        if (!Enum.IsDefined(dayOfWeek))
            throw new ArgumentException("Invalid day of week.");
        
        Court = court;
        CourtId = court.Id;
        DayOfWeek = dayOfWeek;
        HourRange= hourRange;
        PricePerHour = pricePerHour;
    }
}