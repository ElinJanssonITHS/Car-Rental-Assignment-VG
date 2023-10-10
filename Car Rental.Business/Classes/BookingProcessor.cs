using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Classes;
using Car_Rental.Common.Extensions;
namespace Car_Rental.Business.Classes;
public class BookingProcessor
{ 
    public string ErrorMessage { get; private set; } = string.Empty;
    public VehicleStatuses Filter { get; set; } = default;

    public Vehicle NewVehicle = new();
    public Customer NewCustomer = new();
    public Booking NewBooking = new();

    private readonly IData _db;

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

    public async Task<IBooking> RentVehicleAsync(int vehicleId, int custumerId)
    {
        return null;
    }

    /*Vehicle*/
    public IVehicle? GetVehicle(int vehicleId) => _db.Single<IVehicle>(v => v.Id.Equals(vehicleId));

    public IVehicle? GetVehicle(string regNo) => _db.Single<IVehicle>(v => v.RegNo.Equals(regNo));

    public void AddVehicle(string make, string registrationNumber, double odometer, double costKm, VehicleStatuses status, VehicleTypes type) 
    {
        ErrorMessage = string.Empty;
        try
        {
            if (make == default || make.Trim().Length.Equals(0) || registrationNumber == default || registrationNumber.Trim().Length.Equals(0) ||
            odometer == default || costKm == default || type == default)
            {
                ErrorMessage = "Could not add vehicle.";
            }
            else
            {
                if (type == VehicleTypes.Motorcycle)
                {
                    _db.Add<IVehicle>(new Motorcycle(_db.NextVehicleId, make, registrationNumber.ToUpper(), odometer, costKm, status, type));
                }
                _db.Add<IVehicle>(new Car(_db.NextVehicleId, make, registrationNumber.ToUpper(), odometer, costKm, status, type));
            }
            NewVehicle = new();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }      
    }

    /*Bookings*/
    public IBooking ReturnVehicle(int vehicleId, double distance)
    {
        var booking = _db.ReturnVehicle(vehicleId, distance);
        
        
        return booking; // temp
    }

    /*Custumer*/
    public IPerson? GetPerson(string ssn) => _db.Single<IPerson>(p => p.SocialSecurityNumber.Equals(ssn));
    public void AddCustomer(string firstName, string lastName, string socialSecurityNumber) 
    {
        ErrorMessage = string.Empty;
        socialSecurityNumber.Trim();
        try
        {
            if (firstName == default || firstName.Trim().Length.Equals(0) || lastName == default || lastName.Trim().Length.Equals(0) ||
                socialSecurityNumber == default || socialSecurityNumber.Length != 6)
            {
                ErrorMessage = "Could not add customer: Fields cannot be empty";
                if (socialSecurityNumber == default || socialSecurityNumber.Length != 6)
                {
                    ErrorMessage += ": Invalid Social Security Number";
                    NewCustomer.SocialSecurityNumber = string.Empty;
                }
            }
            else
            {
                _db.Add<IPerson>(new Customer(_db.NextPersonId, firstName, lastName, socialSecurityNumber));
                NewCustomer = new();
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        } 
    }
    public string[] VehicleStatusNames => _db.VehicleStatusNames;
    public string[] VehicleTypeNames => _db.VehicleTypeNames;
    public VehicleTypes GetVehicleType(string name) => _db.GetVehicleType(name);

}