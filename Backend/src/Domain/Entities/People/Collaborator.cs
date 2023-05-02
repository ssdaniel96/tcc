using System.Drawing;

namespace Domain.Entities.People;

public sealed class Collaborator : Entity
{
    public string Name { get; private set; }

    private Collaborator()
    {
        
    }

    public Collaborator(string name)
    {
        Name = name;
    }
}