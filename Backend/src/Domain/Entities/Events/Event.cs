using Domain.Entities.Equipments;
using Domain.Entities.Locations;
using Domain.Enums;

namespace Domain.Entities.Events;

public sealed class Event : Entity
{
    public Location Location { get; private set; }
    public Equipment Equipment { get; private set; }
    public MovimentTypeEnum MovimentType { get; private set; }
    public DateTime EventDateTime { get; private set; }

#pragma warning disable CS8618
    private Event()
#pragma warning restore CS8618
    {

    }
    public Event(Location location, Equipment equipment, MovimentTypeEnum movimentType)
    {
        Location = location;
        Equipment = equipment;
        MovimentType = movimentType;
        EventDateTime = DateTime.UtcNow;
    }
}