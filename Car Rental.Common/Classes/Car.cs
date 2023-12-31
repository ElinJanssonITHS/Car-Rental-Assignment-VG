﻿using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Classes;

public class Car : Vehicle
{
    public Car(int id, string make, string regNo, double odometer, double costKm, VehicleStatuses status, VehicleTypes type)
        : base(id, make, regNo, odometer, costKm, status, type) { }
}
