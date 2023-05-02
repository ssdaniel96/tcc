using Application.Dtos;
using AutoMapper;
using Domain.Entities.Events;

namespace Application.Mapping;

internal sealed class EventDtoProfile : Profile
{
    public EventDtoProfile()
    {
        CreateMap<Event, EventDto>()
            .ForMember(p => p.EventDateTime, c => c.MapFrom(p => p.EventDateTime))
            .ForMember(p => p.RFTag, c => c.MapFrom(p => p.Equipment.RFTag))
            .ForMember(p => p.EquipmentDescription, c => c.MapFrom(p => p.Equipment.Description))
            .ForMember(p => p.LocationDescription, c => c.MapFrom(p => p.Location.Description))
            .ForMember(p => p.LocationLevel, c => c.MapFrom(p => p.Location.Level))
            .ForMember(p => p.MovimentType, c => c.MapFrom(p => p.MovimentType));
    }
}
