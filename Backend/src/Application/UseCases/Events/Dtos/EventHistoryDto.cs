using Domain.Enums;

namespace Application.UseCases.Events.Dtos;

public sealed record EventHistoryDto
{
    public int Id { get; init; }
    public string EquipmentDescription { get; init; } = string.Empty;
    public string EquipmentRfTag { get; init; } = string.Empty;
    public string LocationDescription { get; init; } = string.Empty;
    public string LocationLevel { get; init; } = string.Empty;
    public string LocationBuilding { get; init; } = string.Empty;
    public string LocationZipCode { get; init; } = string.Empty;
    public string LocationNumber { get; init; } = string.Empty;
    public string EventDateTime { get; init; } = string.Empty;
    public Vector EventVector { get; init; }
}
