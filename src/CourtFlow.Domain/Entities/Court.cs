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
        Id = Guid.NewGuid();
        Name = name;
        Sport = sport;
        isActive = true;
    }
}