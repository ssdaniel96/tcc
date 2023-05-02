namespace Domain.Entities.Locations;

public sealed class Building : Entity
{
    public Address Address { get; private set; }
    public string Description { get; private set; }

    private Building()
    {
        
    }

    public Building(Address address, string description)
    {
        Address = address;
        Description = description;
    }
}