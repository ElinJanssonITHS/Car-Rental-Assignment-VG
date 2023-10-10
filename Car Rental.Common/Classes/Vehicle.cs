
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Vehicle : IVehicle 
{
    public int Id { get; init; }
    public string Make { get; set; } = string.Empty;
    public string RegNo { get; set; } = string.Empty;
    public double Odometer { get; set; }
    public double CostKm { get; set; }
    public VehicleStatuses Status { get; private set; }
    public VehicleTypes Type { get; set; }
    public Vehicle() { }
    public Vehicle(int id, string make, string regNo, double odometer, double costKm, VehicleStatuses status, VehicleTypes type)
        => (Id, Make, RegNo, Odometer, CostKm, Status, Type) = (id, make, regNo, odometer, costKm, status, type);
    public void ChangeStatus(VehicleStatuses status) => Status = status;
    public virtual void UpdateOdometer(double km) => Odometer += km;

}
