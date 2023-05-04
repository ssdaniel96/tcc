namespace Application.Dtos;

public sealed record EquipmentDto
{
    public string RFTag { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}
