using CourtFlow.Domain.Enums;

namespace CourtFlow.Domain.Entities;

public class Court
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Sport Sport { get; private set; }
    public bool isActive { get; private set; }

    protected Court()
    {
    }

    public Court(string name, Sport sport)
    {
        ValidateCommon(name);
        Id = Guid.NewGuid();
        Name = name;
        Sport = sport;
        isActive = true;
    }

    private void ValidateCommon(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < 3 || name.Length > 100)
            throw new ArgumentException("Invalid name");

    }
}