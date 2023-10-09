using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Classes;
using System.Linq.Expressions;
using System.Linq;
using System.Reflection;

namespace Car_Rental.Data.Classes;
public class CollectionData : IData
{
    readonly List<IVehicle> _vehicles = new List<IVehicle>();
    readonly List<IPerson> _persons = new List<IPerson>();
    readonly List<IBooking> _bookings = new List<IBooking>();

    public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(i => i.Id) + 1;
    public int NextPersonId => _persons.Count.Equals(0) ? 1 : _persons.Max(i => i.Id) + 1;
    public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(i => i.Id) + 1;

    public CollectionData() => SeedData();
    void SeedData()
    {
        Customer customer1 = new(1, "Alex", "Smith", "12345");
        Customer customer2 = new(2, "Sandra", "Smith", "98765");
        Customer customer3 = new(3, "Jane", "Carlsson", "92345");

        Car car1 = new(1, "Volvo", "ABC123" , 10000, 1, VehicleStatuses.Available, VehicleTypes.Combi);
        Car car2 = new(2, "Saab", "DEF456", 22000, 1, VehicleStatuses.Available, VehicleTypes.Combi);
        Car car3 = new(3, "Tesla", "GHI789", 2000, 3, VehicleStatuses.Available, VehicleTypes.Sedan);
        Car car4 = new(4, "Jeep", "JKL321", 5000, 1.5, VehicleStatuses.Available, VehicleTypes.Van);
        Motorcycle motorcycle = new(5, "Yamaha", "MNO654", 6000, 1, VehicleStatuses.Available, VehicleTypes.Motorcycle);

        Booking booking1 = new(1, customer2, car4);
        Booking booking2 = new(2, customer1, car3);
        Booking booking3 = new(3, customer3, car1);

        _persons.Add(customer1);
        _persons.Add(customer2);
        _persons.Add(customer3);

        _vehicles.Add(car1);
        _vehicles.Add(car2);
        _vehicles.Add(car3);
        _vehicles.Add(car4);
        _vehicles.Add(motorcycle);

        _bookings.Add(booking1);
        _bookings.Add(booking2);
        _bookings.Add(booking3);

        booking1.ReturnVehicle(car4, 0);
        booking3.ReturnVehicle(car1, 50);

    }

    public List<T> Get<T>(Expression<Func<T, bool>>? expression) // Generisk metod Get<>(); KLAR
    {
        FieldInfo fieldInfo = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.FieldType == typeof(List<T>));
        if (fieldInfo != null)
        {
            var list = (List<T>)fieldInfo.GetValue(this);

            if (expression != null)
            {
                list = list.Where(expression.Compile()).ToList();
            }
            return list;
        }
        throw new InvalidOperationException($"No list of type {typeof(T)} found.");
    }

    public T? Single<T>(Expression<Func<T, bool>>? expression) // Generisk metod Single<>(); Nästan klar. Felhantering kan behövas
    {
        FieldInfo fieldInfo = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.FieldType == typeof(List<T>));

        if (fieldInfo != null)
        {
            var list = (List<T>)fieldInfo.GetValue(this);

            if (expression != null)
            {
                var item = list.SingleOrDefault(expression.Compile());

                if (item != null)
                {
                    return item;
                }
            }
            throw new InvalidOperationException($"No matching element of type {typeof(T)} found.");
        }

        throw new InvalidOperationException($"No type of {typeof(T)} found.");
    }

    public void Add<T>(T item)
    {
        FieldInfo fieldInfo = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.FieldType == typeof(List<T>));
        if (fieldInfo != null)
        {
            var list = (List<T>)fieldInfo.GetValue(this);
            if(item != null)
            {
                list.Add(item);
            }
            else
            {
                throw new ArgumentNullException($"Could not add null element of type {typeof(T)}.");
            }
        }
        else
        {
            throw new InvalidOperationException($"No type of {typeof(T)} found.");
        }
    }

    public IBooking RentVehicle(int vehicleId, int custumerId)
    {
        throw new NotImplementedException();
    }

    public IBooking ReturnVehicle(int vehicleId)
    {
        throw new NotImplementedException();
    }

    /*public IEnumerable<IBooking> GetBooking() => _bookings;
    public IEnumerable<IPerson> GetPersons() => _persons;
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _vehicles;*/
}