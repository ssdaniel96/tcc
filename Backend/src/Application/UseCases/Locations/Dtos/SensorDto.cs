namespace Application.UseCases.Locations.Dtos;

public record SensorDto
{
    public LocationDto LocationDto { get; init; } = new();
    public string Description { get; init; } = string.Empty;
    public int Id { get; init; }
}