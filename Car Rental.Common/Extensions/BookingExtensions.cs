
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Extensions;

public static class BookingExtensions
{
    public static void Return(this IBooking booking, double distance)
    {
        booking.Vehicle.ChangeStatus(VehicleStatuses.Available);
        booking.DayOfReturn = DateTime.Now;
        booking.RentalStatus = false;
        booking.Vehicle.UpdateOdometer(distance);
        booking.Cost = VehicleExtensions.Duration(booking.DayOfRent, booking.DayOfReturn) * booking.Vehicle.CostDay + distance * booking.Vehicle.CostKm;
    }
}
