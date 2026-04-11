using System.Text.RegularExpressions;

namespace CourtFlow.Domain.ValueObjects;

public record Password
{
    public string Value { get; }

    public Password(string value)
    {

        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Password cannot be empty");

        var isValidPassword = Regex.IsMatch(value, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[#?!@$%^&*-]).{8,}$");
        if (!isValidPassword)
            throw new ArgumentException("Invalid password");

        Value = value;
    }

    // For EF Core only — skips validation
    private Password(){}
};