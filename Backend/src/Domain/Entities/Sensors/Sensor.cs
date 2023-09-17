using Domain.Entities.Locations;
using Domain.Exceptions;

namespace Domain.Entities.Sensors;

public class Sensor : Entity
{
    public string Description { get; private set; }
    public Location Location { get; private set; }
    public int LocationId { get; private set; }

#pragma warning disable CS8618 
    private Sensor()
#pragma warning restore CS8618 
    {
        
    }
    
    public Sensor(int id, string description, Location location) : base(id)
    {
        ValidateDescription(description);
        Description = description;
        Location = location;
        LocationId = location.Id;
    }
    
    private static void ValidateDescription(string description)
    {
        if (string.IsNullOrEmpty(description))
        {
            throw new DomainException("A descrição do sensor está nula!");
        }

        if (description.Length > 20)
        {
            throw new DomainException("A descrição está grande demais, extensão máxima permitida: 20");
        }

        if (description.Length < 3)
        {
            throw new DomainException("A descrição está muito curta, extensão mínima permitida: 3");
        }
    }
}