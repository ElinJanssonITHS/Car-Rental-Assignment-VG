using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IVehicle
{
    string RegNo { get; }
    string Make { get; }
    double Odometer { get; }
    VehicleTypes Type { get; }
    double CostKm { get; }
    double CostDay => (int)Type;
    VehicleStatuses Status { get; }
    void ChangeStatus(VehicleStatuses status);
    void UpdateOdometer(double km);

}
