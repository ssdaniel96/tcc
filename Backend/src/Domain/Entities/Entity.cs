using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Domain.Exceptions;

namespace Domain.Entities;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
public abstract class Entity
{
    public int Id { get; protected init; }
    protected Entity(int id)
    {
        Id = id;
    }

    private void ValidateId(int id)
    {
        if (id > 0) return;
        
        var className = GetType().Name;
        throw new DomainException($"{className} cant has id less or equal 0! Actual Value: {id}");
    }
    
    protected Entity()
    {
    }
}