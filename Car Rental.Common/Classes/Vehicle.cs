
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public abstract class Vehicle : IVehicle
{
    public int Id { get; init; }
    public string Make { get; init; } = string.Empty;
    public string RegNo { get; init; } = string.Empty;
    public double Odometer { get; private set; }
    public double CostKm { get; init; }
    public VehicleStatuses Status { get; private set; }
    public VehicleTypes Type { get; init; }
    public Vehicle(int id, string make, string regNo, double odometer, double costKm, VehicleStatuses status, VehicleTypes type)
        => (Id, Make, RegNo, Odometer, CostKm, Status, Type) = (id, make, regNo, odometer, costKm, status, type);
    public void ChangeStatus(VehicleStatuses status) => Status = status;
    public virtual void UpdateOdometer(double km) => Odometer += km;

}
