namespace Domain.Entities.Locations;

public sealed class Location : Entity
{
    public string Description { get; private set; }
    public string Level { get; private set; }
    public Building Building { get; private set; }

#pragma warning disable CS8618
    private Location()
#pragma warning restore CS8618
    {

    }

    public Location(string description, string level, Building building)
    {
        Description = description;
        Level = level;
        Building = building;
    }
}