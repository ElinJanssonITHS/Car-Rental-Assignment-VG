using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Extensions;

public static class CollectionExtensions
{
    public static void Return(this IBooking booking, double distance)
    {
        booking.Vehicle.ChangeStatus(VehicleStatuses.Available);
        booking.DayOfReturn = DateTime.Now;
        booking.RentalStatus = false;
        booking.Vehicle.UpdateOdometer(distance);
        booking.Cost = VehicleExtensions.Duration(booking.DayOfRent, booking.DayOfReturn) * booking.Vehicle.CostDay + distance * booking.Vehicle.CostKm;

    }
    /*public IVehicle ReturnVehicle(int vehicleID, double kmDriven)
{
    Vehicle.ChangeStatus(VehicleStatuses.Available); *
    Vehicle.UpdateOdometer(kmDriven); *
    DayOfReturn = DateTime.Now; *
    _daysRented = VehicleExtensions.Duration(DayOfRent, DayOfReturn); *
    Cost = _daysRented * vehicle.CostDay + kmDriven * vehicle.CostKm; *
    RentalStatus = false; *
    return Vehicle;
}*/

}
