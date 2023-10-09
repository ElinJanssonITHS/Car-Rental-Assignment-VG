using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Enums;
using System.Runtime.Intrinsics.X86;
using Car_Rental.Common.Classes;
namespace Car_Rental.Business.Classes;
public class BookingProcessor
{
    public string ErrorMessage { get; private set; } = string.Empty;
    public string NewRegNo { get; set; } public string NewMake { get; set; }
    public double NewOdometer { get; set; } public double NewCostKm { get; set; }
    public VehicleTypes NewType { get; set; }
    public string NewFirstName { get; set; } public string NewLastName { get; set; } public string NewSSN { get; set; }

    private readonly IData _db;

    public VehicleStatuses[] VehicleStatus { get; } = { VehicleStatuses.Booked, VehicleStatuses.Available };
    public VehicleStatuses Filter { get; set; } = default;

    public BookingProcessor(IData db) => _db = db;

    public IEnumerable<IPerson> GetCustomers()
    {
        return _db.Get<IPerson>(null).OrderBy(c => c.LastName);
    }
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default)
    {
        if (status == default)
        {
            return _db.Get<IVehicle>(null);
        }
        return _db.Get<IVehicle>(v => v.Status.Equals(status));
    }
    public IEnumerable<IBooking> GetBookings()
    {
        return _db.Get<IBooking>(null).OrderBy(b => b.RentalStatus);
    }

    //public async Task<IBooking> RentVehicle(int vehicleId, int custumerId) { }

    /*Vehicle*/
    public IVehicle? GetVehicle(int vehicleId) => _db.Single<IVehicle>(v => v.Id.Equals(vehicleId));

    public IVehicle? GetVehicle(string regNo) => _db.Single<IVehicle>(v => v.RegNo.Equals(regNo));

    public void AddVehicle(string make, string registrationNumber, double odometer, double costKm, VehicleStatuses status, VehicleTypes type) 
    {
        if(type == VehicleTypes.Motorcycle)
        {
            _db.Add<IVehicle>(new Motorcycle(_db.NextVehicleId, make, registrationNumber, odometer, costKm, status, type));
        }
        _db.Add<IVehicle>(new Car(_db.NextVehicleId, make, registrationNumber, odometer, costKm, status, type));
    }

    /*Bookings*/
    //public IBooking ReturnVehicle(int vehicleId, double distance) { }

    /*Custumer*/
    public IPerson? GetPerson(string ssn) => _db.Single<IPerson>(p => p.SocialSecurityNumber.Equals(ssn));
    public void AddCustomer(string firstName, string lastName, string socialSecurityNumber) 
    {
        _db.Add<IPerson>(new Customer(_db.NextPersonId, firstName, lastName, socialSecurityNumber));
    }



    public string[] VehicleStatusNames => _db.VehicleStatusNames;
    public string[] VehicleTypeNames => _db.VehicleTypeNames;
    public VehicleTypes GetVehicleType(string name) => _db.GetVehicleType(name);

}