namespace Domain.Entities.Locations;

public sealed class Address : Entity
{
    public string ZipCode { get; private set; }
    public string Number { get; private set; }
    public string? Complement { get; private set; }
    public string? Observation { get; private set; }

#pragma warning disable CS8618
    private Address()
#pragma warning restore CS8618
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