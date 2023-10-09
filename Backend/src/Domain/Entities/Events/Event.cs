using Domain.Entities.Equipments;
using Domain.Entities.Locations;
using Domain.Entities.Sensors;
using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities.Events;

public sealed class Event : Entity
{
    public int SensorId { get; private set; }
    public int LocationId { get; private set; }
    public int EquipmentId { get; private set; }
    public Vector MovimentType { get; private set; }
    public DateTime EventDateTime { get; private set; }
    
    
    public Sensor Sensor { get; private set; }
    public Location Location { get; private set; }
    public Equipment Equipment { get; private set; }


#pragma warning disable CS8618
    private Event()
#pragma warning restore CS8618
    {

    }
    public Event(Sensor sensor, Equipment equipment, Vector movimentType)
    {
        ValidateMovimentType(movimentType);

        Sensor = sensor;
        SensorId = sensor.Id;
        Location = sensor.Location;
        LocationId = sensor.LocationId;
        Equipment = equipment;
        EquipmentId = equipment.Id;
        MovimentType = movimentType;
        EventDateTime = DateTime.Now;
    }

    private static void ValidateMovimentType(Vector vector)
    {
        var permittedValues = Enum.GetValues<Vector>()
            .Select(x => (int)x);
        
        if (!Enum.IsDefined<Vector>(vector))
        {
            throw new DomainException(
                $"Valor do Tipo de Movimento inválido ({vector})! Valores aceitáveis: {string.Join(", ", permittedValues)}");
        }

    }
}