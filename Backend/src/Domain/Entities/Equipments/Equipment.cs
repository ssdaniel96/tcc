using Domain.Entities.Events;
using Domain.Exceptions;

namespace Domain.Entities.Equipments;

public sealed class Equipment : Entity
{
    public string RFTag { get; private set; }
    public string Description { get; private set; }

    //navigations
    public IReadOnlyList<Event> Events => _events.AsReadOnly();
    private readonly List<Event> _events = new();

#pragma warning disable CS8618
    private Equipment()
#pragma warning restore CS8618
    {

    }

    public Equipment(string rfTag, string description)
    {
        ValidateRfTag(rfTag);
        ValidateDescription(description);
        
        RFTag = rfTag;
        Description = description;
    }

    private static void ValidateRfTag(string rfTag)
    {
        if (string.IsNullOrEmpty(rfTag))
        {
            throw new DomainException("A RfTag está nula!");
        }

        if (rfTag.Length > 100)
        {
            throw new DomainException("A RfTag está grande demais, extensão máxima permitida: 100");
        }
        
        if (rfTag.Length < 3)
        {
            throw new DomainException("A RfTag está muito curta, extensão mínima permitida: 3");
        }

    }

    private static void ValidateDescription(string description)
    {
        if (string.IsNullOrEmpty(description))
        {
            throw new DomainException("A descrição do equipamento está nula!");
        }
        
        if (description.Length > 100)
        {
            throw new DomainException("A descrição está grande demais, extensão máxima permitida: 100");
        }
        
        if (description.Length < 3)
        {
            throw new DomainException("A descrição está muito curta, extensão mínima permitida: 3");
        }
    }
}