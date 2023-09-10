namespace Application.UseCases.Locations.Dtos;

public record BuildingDto 
{
    public int Id { get; init; }
    public AddressDto? Address { get; init; } = new();
    public string? Description { get; init; }

    public BuildingDto()
    {
        
    }

    public BuildingDto(AddressDto? address, string? description)
    {
        Address = address;
        Description = description;
    }
}