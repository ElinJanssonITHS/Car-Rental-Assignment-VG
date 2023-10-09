namespace Car_Rental.Common.Interfaces
{
    public interface IPerson
    {
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
        string SocialSecurityNumber { get; }
        string CustomerInformation { get; }
    }
}
