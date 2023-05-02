namespace Domain.Entities.People;

public sealed class Collaborator : Entity
{
    public string Name { get; private set; }

#pragma warning disable CS8618
    private Collaborator()
#pragma warning restore CS8618
    {

    }

    public Collaborator(string name)
    {
        Name = name;
    }
}