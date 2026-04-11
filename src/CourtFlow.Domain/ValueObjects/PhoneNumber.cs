using System.Text.RegularExpressions;

namespace CourtFlow.Domain.ValueObjects;

public record PhoneNumber
{
    public string Value { get; }

    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Phone number cannot be empty.");

        var isValidPhone = Regex.IsMatch(value ?? "", @"^(\+968)?[279]\d{7}$");
        if (!isValidPhone)
            throw new ArgumentException("Invalid Oman phone number.");
        Value = value;
    }
};