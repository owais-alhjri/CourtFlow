using CourtFlow.Application.Common;

namespace CourtFlow.Application.Features.Courts;

public static class CourtErrors
{
    public static readonly Error NotFound = new("Court.NotFound", "Court was not found.");
    public static readonly Error AlreadyBooked = new("Court.AlreadyBooked", "This slot is already booked.");
}

/*
 this is how you will use it later 
if (court is null)
   return CourtErrors.NotFound; // implicit operator kicks in
 */