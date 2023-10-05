using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Car : Vehicle
{
    public Car(string make, string regNo, double odometer, double costKm, VehicleStatuses status, VehicleTypes type)
        : base(make, regNo, odometer, costKm, status, type) { }
}
