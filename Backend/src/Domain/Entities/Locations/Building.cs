using Domain.Exceptions;

namespace Domain.Entities.Locations;

public sealed class Building : Entity
{
    public int AddressId { get; private set; }
    public Address Address { get; private set; }
    public string Description { get; private set; }
    
    //navigations
    public IReadOnlyCollection<Location> Locations => _locations.AsReadOnly();
    private List<Location> _locations = new List<Location>();

#pragma warning disable CS8618
    private Building()
#pragma warning restore CS8618
    {

    }

    public Building(Address address, string description)
    {
        ValidateDescription(description);
        
        Address = address;
        AddressId = address.Id;
        Description = description;
    }

    private static void ValidateDescription(string? description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new DomainException("A descrição não pode ser nula!");
        }

        if (description.Length > 100)
        {
            throw new DomainException(
                $"A descrição excede o limite máximo de caracteres (100), tamanho atual: {description.Length}");
        }

        if (description.Length < 3)
        {
            throw new DomainException(
                $"A descrição precisa ter pelo menos 3 caracteres, tamanho atual: {description.Length}");
        }
    }
}