using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Enums;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    private readonly IData _db;
    public VehicleStatuses[] VehicleStatus { get; } = { VehicleStatuses.Booked, VehicleStatuses.Available };
    public BookingProcessor(IData db) => _db = db;
    public VehicleStatuses Filter { get; set; } = default;

    public IEnumerable<IPerson> GetCustomers()
    {
        return _db.GetPersons().OrderBy(c => c.LastName);
    }
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default)
    {
        if (status == default)
        {
            return _db.GetVehicles();
        }
        return _db.GetVehicles().Where(v => v.Status.Equals(status));
    }
    public IEnumerable<IBooking> GetBookings()
    {
        return _db.GetBooking().OrderBy(b => b.RentalStatus);
    }

    //public async Task<IBooking> RentVehicle(int vehicleId, int custumerId) { }

    /*Vehicle*/
    //public IVehicle? GetVehicle(int vehicleId) { }
    //public IVehicle? GetVehicle(string regNo) { }
    public void AddVehicle(string make, string registrationNumber, double odometer, double costKm, VehicleStatuses status, VehicleTypes type) { }

    /*Bookings*/
    //public IBooking ReturnVehicle(int vehicleId, double distance) { }

    /*Custumer*/
    //public IPerson? GetPerson(string ssn) { }
    public void AddCustomer(string socialSecurityNumber, string firstName, string lastName) { }



    public string[] VehicleStatusNames => _db.VehicleStatusNames;
    public string[] VehicleTypeNames => _db.VehicleTypeNames;
    public VehicleTypes GetVehicleType(string name) => _db.GetVehicleType(name);

}