using Domain.Entities.Events;
using Domain.Entities.People;

namespace Domain.Entities.Equipments;

public sealed class Equipment : Entity
{
    public string RFTag { get; private set; }
    public string Description { get; private set; }
    public Collaborator Responsible { get; private set; }

    //navigations
    public IReadOnlyList<Event> Events => _events.AsReadOnly();
    private readonly List<Event> _events = new();

    public Equipment(string rfTag, string description, Collaborator responsible)
    {
        RFTag = rfTag;
        Description = description;
        Responsible = responsible;
    }
}