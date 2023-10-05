namespace Car_Rental.Common.Interfaces
{
    public interface IPerson
    {
        string FirstName { get; }
        string LastName { get; }
        int SocialSecurityNumber { get; }
        string CustomerInformation { get; }
    }
}
