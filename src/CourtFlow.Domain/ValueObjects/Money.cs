namespace CourtFlow.Domain.ValueObjects;

public record Money
{
    public decimal Value { get; }

    public Money(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("Money can not be negative");

        Value = value;
    }
    private Money() { }  // EF Core — only needed if used with OwnsOne

}
