namespace Car_Rental.Common.Interfaces;

public interface IPerson
{
    int Id { get; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string SocialSecurityNumber { get; }
    string CustomerInformation { get; } 
}
