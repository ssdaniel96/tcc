namespace Application.UseCases.Equipments.Dtos;

public sealed record EquipmentDto
{
    public int Id { get; init; }
    public string RfTag { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}
