using Application.UseCases.Equipments.Dtos;
using Application.UseCases.Events.Dtos;
using Application.UseCases.Locations.Dtos;
using AutoMapper;
using Domain.Entities.Equipments;
using Domain.Entities.Events;
using Domain.Entities.Locations;

namespace Application.Mappings;

internal sealed class ProfilesConfiguration : Profile
{
    public ProfilesConfiguration()
    {
        CreateMap<Event, EventDto>()
            .ForMember(p => p.EventDateTime, c => c.MapFrom(p => p.EventDateTime))
            .ForMember(p => p.RFTag, c => c.MapFrom(p => p.Equipment.RFTag))
            .ForMember(p => p.EquipmentDescription, c => c.MapFrom(p => p.Equipment.Description))
            .ForMember(p => p.LocationDescription, c => c.MapFrom(p => p.Location.Description))
            .ForMember(p => p.LocationLevel, c => c.MapFrom(p => p.Location.Level))
            .ForMember(p => p.MovimentType, c => c.MapFrom(p => p.MovimentType));

        CreateMap<Equipment, EquipmentDto>();
        CreateMap<Location, LocationDto>();
    }
}
