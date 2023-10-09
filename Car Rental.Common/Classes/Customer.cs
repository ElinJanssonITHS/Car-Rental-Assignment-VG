using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Customer : IPerson
{
    public int Id { get; init; }
    public string FirstName {get; init;}
    public string LastName { get; private set; }
    public string SocialSecurityNumber { get; init;}
    public string CustomerInformation => $"{LastName} {FirstName} ({SocialSecurityNumber})";
    public Customer(int id, string firstName, string lastName, string socialSecurityNumber)
        => (Id, FirstName, LastName, SocialSecurityNumber) = (id, firstName, lastName, socialSecurityNumber);


}