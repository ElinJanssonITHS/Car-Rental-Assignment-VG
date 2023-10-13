using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IVehicle
{
    int Id { get; }
    string RegNo { get; set; }
    string Make { get; set; }
    double Odometer { get; set; }
    VehicleTypes Type { get; set; }
    double CostKm { get; set; }
    double CostDay => (int)Type;
    VehicleStatuses Status { get; }
    void ChangeStatus(VehicleStatuses status);
    void UpdateOdometer(double km);
}
