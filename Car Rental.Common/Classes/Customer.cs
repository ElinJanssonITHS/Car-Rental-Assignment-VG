using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Customer : IPerson
{
    public int Id { get; set; }
    public string FirstName {get; set;} = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string SocialSecurityNumber { get; set; } = string.Empty;
    public string CustomerInformation => $"{LastName} {FirstName} ({SocialSecurityNumber})";
    public Customer() { }
    public Customer(int id, string firstName, string lastName, string socialSecurityNumber)
        => (Id, FirstName, LastName, SocialSecurityNumber) = (id, firstName, lastName, socialSecurityNumber);

}