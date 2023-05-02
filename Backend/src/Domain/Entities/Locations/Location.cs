namespace Domain.Entities.Locations;

public sealed class Location : Entity
{
    public string Description { get; private set; }
    public string Level { get; private set; }
    public Building Building { get; private set; }

    private Location()
    {
        
    }
    
    public Location(string description, string level, Building building)
    {
        Description = description;
        Level = level;
        Building = building;
    }
}