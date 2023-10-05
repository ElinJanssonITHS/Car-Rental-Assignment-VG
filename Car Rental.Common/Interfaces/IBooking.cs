
namespace Car_Rental.Common.Interfaces;

public interface IBooking
{
    IPerson Customer { get; init; }
    IVehicle Vehicle { get; init; }
    DateTime DayOfRent { get; init; }
    DateTime DayOfReturn { get; }
    double OdometerBeforeRent { get; init; }
    double Cost { get; }
    bool RentalStatus { get; }


    void ReturnVehicle(IVehicle vehicle, double kmDriven);

}