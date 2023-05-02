namespace Domain.Entities.Locations;

public sealed class Building : Entity
{
    public Address Address { get; private set; }
    public string Description { get; private set; }

#pragma warning disable CS8618
    private Building()
#pragma warning restore CS8618
    {

    }

    public Building(Address address, string description)
    {
        Address = address;
        Description = description;
    }
}