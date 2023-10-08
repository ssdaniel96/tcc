namespace Application.UseCases.Locations.Dtos;

public record SensorDto
{
    public LocationDto Location { get; init; } = new();
    public string Description { get; init; } = string.Empty;
    public int Id { get; init; }
}