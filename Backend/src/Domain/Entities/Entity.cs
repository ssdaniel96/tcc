using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
public abstract class Entity
{
    public int Id { get; private set; }
    
    protected Entity()
    {
    }
}