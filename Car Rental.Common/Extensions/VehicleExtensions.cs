
namespace Car_Rental.Common.Extensions;

public static class VehicleExtensions
{
    public static int Duration(this DateTime startDate, DateTime endDate)
    {
        var duration = (int)(endDate - startDate).TotalDays;
        return duration < 1 ? 1 : duration;
    }
}
