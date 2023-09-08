namespace Application.UseCases.Locations.Dtos;

public record AddressDto
{
    public int Id { get; init; }
    public string? ZipCode { get; init; }
    public string? Number { get; init; }
    public string? Complement { get; init; }
    public string? Observation { get; init; }

    public AddressDto()
    {
        
    }

    public AddressDto(string? zipCode, string? number, string? complement, string? observation)
    {
        ZipCode = zipCode;
        Number = number;
        Complement = complement;
        Observation = observation;
    }
}