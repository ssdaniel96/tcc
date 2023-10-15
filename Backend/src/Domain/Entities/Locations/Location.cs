using System.Data;
using Domain.Entities.Events;
using Domain.Entities.Sensors;
using Domain.Exceptions;

namespace Domain.Entities.Locations;

public class Location : Entity
{
    public string Description { get; private set; }
    public string Level { get; private set; }
    public Building Building { get; private set; }

    //navigations
    public IReadOnlyCollection<Sensor> Sensors => _sensors.AsReadOnly();
    private readonly List<Sensor> _sensors = new();
    
    public IReadOnlyCollection<Event> Events => _events.AsReadOnly();
    private List<Event> _events = new List<Event>();

#pragma warning disable CS8618
    private Location()
#pragma warning restore CS8618
    {

    }

    public Location(string description, string level, Building building)
    {
        ValidateDescription(description);
        ValidateLevel(level);
        
        Description = description;
        Level = level;
        Building = building;
    }

    public void AddSensor(Sensor sensor)
    {
        if (_sensors.Select(p => p.Id).Contains(sensor.Id))
        {
            throw new DomainException($"A localização ({Id}) já possui esse sensor ({sensor.Id}) instalado!");
        }
        
        _sensors.Add(sensor);
    }

    public void RemoveSensor(Sensor sensor)
    {
        if (!_sensors.Select(p => p.Id).Contains(sensor.Id))
        {
            throw new DomainException($"A localização ({Id}) não possui esse sensor ({sensor.Id}) instalado!");
        }

        _sensors.Remove(sensor);
    }

    private static void ValidateLevel(string? level)
    {
        if (string.IsNullOrWhiteSpace(level))
        {
            throw new DomainException("O andar não pode ser nulo!");
        }
        

        if (level.Length > 100)
        {
            throw new DomainException(
                $"O andar excede o tamanho máximo de caracteres (100). Tamanho atual: {level.Length}");
        }
    }

    private static void ValidateDescription(string? description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new DomainException("A descrição não pode ser nula!");
        }

        if (description.Length < 3)
        {
            throw new DomainException(
                $"A descrição precisa ter pelo menos 3 caracteres! Limite atual: {description.Length}");
        }

        if (description.Length > 100)
        {
            throw new DomainException(
                $"A descrição excede o tamanho máximo de caracteres (100). Tamanho atual: {description.Length}");
        }
    }
}