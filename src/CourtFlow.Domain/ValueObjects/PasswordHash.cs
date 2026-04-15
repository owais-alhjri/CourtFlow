namespace CourtFlow.Domain.ValueObjects;

public record PasswordHash
{
    public string Value { get; }

    public PasswordHash(string value) 
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Invalid hash");

        Value = value;
    }
}