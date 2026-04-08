namespace CourtFlow.Application.Common;

public record Error(string Code, string Massage)
{
    public static readonly Error None = new(string.Empty, string.Empty);
}