using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Customer : IPerson
{
    private string _firstName;
    private string _lastName;
    private int _socialSecurityNumber;
    public string FirstName => _firstName;
    public string LastName => _lastName;
    public int SocialSecurityNumber => _socialSecurityNumber;
    public string CustomerInformation => $"{LastName} {FirstName} ({SocialSecurityNumber})";
    public Customer(string firstName, string lastName, int socialSecurityNumber)
        => (_firstName, _lastName, _socialSecurityNumber) = (firstName, lastName, socialSecurityNumber);


}