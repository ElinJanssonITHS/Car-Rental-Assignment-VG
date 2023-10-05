using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Classes;

public class Motorcycle : Vehicle
{
    public Motorcycle(string make, string regNo, double odometer, double costKm, VehicleStatuses status, VehicleTypes type)
        : base(make, regNo, odometer, costKm, status, type) { }

}

