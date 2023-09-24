using Domain.Enums;

namespace Application.UseCases.Events.Dtos;

public sealed record EventDto
{
    public string RFTag { get; init; } = string.Empty;
    public string EquipmentDescription { get; init; } = string.Empty;
    public string LocationDescription { get; init; } = string.Empty;
    public string LocationLevel { get; init; } = string.Empty;
    public DateTime EventDateTime { get; init; }
    public Vector MovimentType { get; init; }
}
