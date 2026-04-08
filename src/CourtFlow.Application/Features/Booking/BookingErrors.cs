using CourtFlow.Application.Common;

namespace CourtFlow.Application.Features.Booking;

public static class BookingErrors
{
    public static readonly Error NotFound = new("Booking.NotFound", "Booking was not found");
}