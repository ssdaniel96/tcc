namespace Application.UseCases.Locations.Dtos;

public sealed record LocationDto
{
    public int Id { get; init; }
    public string Description { get; init; } = string.Empty;
    public string Level { get; init; } = string.Empty;
}
