using Car_Rental.Common.Enums;
using System.Linq.Expressions;

namespace Car_Rental.Common.Interfaces;

public interface IData
{
    List<T> Get<T>(Expression<Func<T, bool>>? expression);
    T? Single<T>(Expression<Func<T, bool>>? expression);
    public void Add<T>(T item);

    int NextVehicleId { get; }
    int NextPersonId { get; }
    int NextBookingId { get; }

    IBooking RentVehicle(int vehicleId, int custumerId);
    IBooking ReturnVehicle(int vehicleId, double distance);

    public string[] VehicleStatusNames => Enum.GetNames(typeof(VehicleStatuses));
    public string[] VehicleTypeNames => Enum.GetNames(typeof(VehicleTypes));
    public VehicleTypes GetVehicleType(string name) => (VehicleTypes)Enum.Parse(typeof(VehicleTypes), name);



    /*IEnumerable<IPerson> GetPersons();
    IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default);
    IEnumerable<IBooking> GetBooking();*/
}