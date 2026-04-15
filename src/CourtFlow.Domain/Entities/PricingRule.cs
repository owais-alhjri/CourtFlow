namespace CourtFlow.Domain.Entities;

public class PricingRule
{
    public int Id { get; private set; }
    public int CourtId { get; private set; }
    public DayOfWeek DayOfWeek { get; private set; }
    public int StartHour { get; set; }
    public int EndHour { get; set; }
    public decimal PricePerHour { get; set; }


    protected PricingRule()
    {
    }

    public Court Court { get; private set; }

    public PricingRule(Court court, DayOfWeek dayOfWeek, int startHour, int endHour, decimal pricePerHour)
    {
        CourtId = court.Id;
        DayOfWeek = dayOfWeek;
        StartHour = startHour;
        EndHour = endHour;
        PricePerHour = pricePerHour;
    }
}