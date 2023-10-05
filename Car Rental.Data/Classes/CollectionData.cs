using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Classes;
using System.Linq.Expressions;

namespace Car_Rental.Data.Classes;
public class CollectionData : IData
{
    readonly List<IPerson> _persons = new List<IPerson>();
    readonly List<IVehicle> _vehicles = new List<IVehicle>();
    readonly List<IBooking> _bookings = new List<IBooking>();

    public int NextVehicleId => throw new NotImplementedException();

    public int NextPersonId => throw new NotImplementedException();

    public int NextBookingId => throw new NotImplementedException();

    public CollectionData() => SeedData();

    void SeedData()
    {
        Customer customer1 = new("Alex", "Smith", 12345);
        Customer customer2 = new("Sandra", "Smith", 98765);
        Customer customer3 = new("Jane", "Carlsson", 92345);


        Car car1 = new("ABC123", "Volvo", 10000, 1, 200, VehicleStatuses.Available, VehicleTypes.Combi);
        Car car2 = new("DEF456", "Saab", 22000, 1, 100, VehicleStatuses.Available, VehicleTypes.Combi);
        Car car3 = new("GHI789", "Tesla", 2000, 3, 300, VehicleStatuses.Available, VehicleTypes.Sedan);
        Car car4 = new("JKL321", "Jeep", 5000, 1.5, 300, VehicleStatuses.Available, VehicleTypes.Van);
        Motorcycle motorcycle = new("Yamaha", "MNO654", 6000, 1, 200, VehicleStatuses.Available, VehicleTypes.Motorcycle);

        Booking bookning1 = new(customer2, car4);
        Booking bookning2 = new(customer1, car3);
        Booking bookning3 = new(customer3, car1);

        _persons.Add(customer1);
        _persons.Add(customer2);
        _persons.Add(customer3);

        _vehicles.Add(car1);
        _vehicles.Add(car2);
        _vehicles.Add(car3);
        _vehicles.Add(car4);
        _vehicles.Add(motorcycle);

        _bookings.Add(bookning1);
        _bookings.Add(bookning2);
        _bookings.Add(bookning3);

        bookning1.ReturnVehicle(car4, 0);
        bookning3.ReturnVehicle(car1, 50);

    }
    public IEnumerable<IBooking> GetBooking() => _bookings;

    public IEnumerable<IPerson> GetPersons() => _persons;

    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _vehicles;

    public List<T> Get<T>(Expression<Func<T, bool>>? expression)
    {
        throw new NotImplementedException();
    }

    public T? Singel<T>(Expression<Func<T, bool>>? expression)
    {
        throw new NotImplementedException();
    }

    public void Add<T>(T item)
    {
        throw new NotImplementedException();
    }

    public IBooking RentVehicle(int vehicleId, int custumerId)
    {
        throw new NotImplementedException();
    }

    public IBooking ReturnVehicle(int vehicleId)
    {
        throw new NotImplementedException();
    }
}