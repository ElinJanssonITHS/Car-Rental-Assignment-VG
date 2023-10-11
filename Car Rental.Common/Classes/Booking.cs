using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Extensions;
namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    #region Properties
    private int _daysRented;
    public int Id { get; init; }
    public IPerson Customer { get; init; }
    public IVehicle Vehicle { get; set; }
    public string RegNr { get; init; }
    public DateTime DayOfRent { get; init; }
    public DateTime DayOfReturn { get; set; }
    public double Distance { get; set; }
    public double OdometerBeforeRent { get; init; }
    public double Cost { get; set; }
    public bool RentalStatus { get; set; }
    #endregion

    #region Constructors
    public Booking() { }
    public Booking(int id, IPerson customer, IVehicle vehicle)
    {
        Id = id;
        Customer = customer;
        Vehicle = vehicle;
        RegNr = vehicle.RegNo;
        DayOfRent = DateTime.Now;
        OdometerBeforeRent = vehicle.Odometer;
        vehicle.ChangeStatus(VehicleStatuses.Booked);
        RentalStatus = true;
    }
    #endregion

    #region Methods
    public void ReturnBooking(Booking booking)
    {
        booking.Vehicle.ChangeStatus(VehicleStatuses.Available);
        booking.DayOfReturn = DateTime.Now;
        booking.RentalStatus = false;
    }
    public IVehicle ReturnVehicle(IVehicle vehicle, double kmDriven)
    {
        vehicle.ChangeStatus(VehicleStatuses.Available);
        vehicle.UpdateOdometer(kmDriven);
        DayOfReturn = DateTime.Now;
        _daysRented = VehicleExtensions.Duration(DayOfRent, DayOfReturn);
        Cost = _daysRented * vehicle.CostDay + kmDriven * vehicle.CostKm;
        RentalStatus = false;
        return Vehicle;
    }
    #endregion
}