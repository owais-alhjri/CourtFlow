using System.ComponentModel.DataAnnotations;

namespace CourtFlow.Domain.ValueObjects;

public record EmailAddress
{
    public string Value { get; }

    public EmailAddress(string value)
    {
        if (!new EmailAddressAttribute().IsValid(value))
            throw new ArgumentException("Invalid email");
        Value = value;
    }
};