namespace Domain.Entities.Locations;

public sealed class Address : Entity
{
    public string ZipCode { get; private set; }
    public string Number { get; private set; }
    public string? Complement { get; private set; }
    public string? Observation { get; private set; }

    private Address()
    {
        
    }
    
    public Address(string zipCode, string number, string? complement = null, string? observation = null)
    {
        ZipCode = zipCode;
        Number = number;
        Complement = complement;
        Observation = observation;
    }
}