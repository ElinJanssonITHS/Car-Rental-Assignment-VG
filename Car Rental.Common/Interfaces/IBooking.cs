
namespace Car_Rental.Common.Interfaces;

public interface IBooking
{
    int Id { get; }
    IPerson Customer { get; init; }
    IVehicle Vehicle { get; set; }
    DateTime DayOfRent { get; init; }
    DateTime DayOfReturn { get; set; }
    double Distance { get; set; }
    double OdometerBeforeRent { get; init; }
    double Cost { get; set; }
    bool RentalStatus { get; set; }

    //void ReturnVehicle(IVehicle vehicle, double kmDriven);

}