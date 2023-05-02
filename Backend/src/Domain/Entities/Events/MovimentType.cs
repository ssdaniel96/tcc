namespace Domain.Entities.Events;

public sealed class MovimentType : Entity
{
    public string Description { get; private set; }


#pragma warning disable CS8618
    private MovimentType()
#pragma warning restore CS8618
    {

    }

    public MovimentType(string description)
    {
        Description = description;
    }
}
