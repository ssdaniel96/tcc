namespace Domain.Entities.Equipments;

public sealed class Equipment : Entity
{
    public string RFTag { get; private set; }
    public string Description { get; private set; }
    public int ResponsibleId { get; private set; }
    
    //navigations
    public Collaborator Responsible { get; private set; }
    
    public IReadOnlyList<Event> Events => _events.AsReadOnly();
    private List<Event> _events = new List<Event>();

    public Equipment(string rfTag, string description, Collaborator responsible)
    {
        RFTag = rfTag;
        Description = description;
        Responsible = responsible;
        ResponsibleId = responsible.Id;
    }
}