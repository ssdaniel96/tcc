using Domain.Enums;

namespace Application.Dtos;

public sealed class EventDto
{
    public string RFTag { get; init; } = string.Empty;
    public string EquipmentDescription { get; init; } = string.Empty;
    public string LocationDescription { get; init; } = string.Empty;
    public string LocationLevel { get; init; } = string.Empty;
    public DateTime EventDateTime { get; init; }
    public MovimentTypeEnum MovimentType { get; init; }
}
