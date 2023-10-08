using Application.UseCases.Equipments.Dtos;
using Application.UseCases.Events.Dtos;
using Application.UseCases.Locations.Dtos;
using AutoMapper;
using Domain.Entities.Equipments;
using Domain.Entities.Events;
using Domain.Entities.Locations;
using Domain.Entities.Sensors;
using Domain.Repositories.Dtos;

namespace Application.Mappings;

internal sealed class ProfilesConfiguration : Profile
{
    public ProfilesConfiguration()
    {
        CreateMap<Event, EventHistoryDto>()
            .ForMember(p => p.EventDateTime, c => c.MapFrom(p => p.EventDateTime))
            .ForMember(p => p.EquipmentRfTag, c => c.MapFrom(p => p.Equipment.RfTag))
            .ForMember(p => p.EquipmentDescription, c => c.MapFrom(p => p.Equipment.Description))
            .ForMember(p => p.SensorId, c => c.MapFrom(p => p.Sensor.Id))
            .ForMember(p => p.SensorDescription, c => c.MapFrom(p => p.Sensor.Description))
            .ForMember(p => p.LocationDescription, c => c.MapFrom(p => p.Location.Description))
            .ForMember(p => p.LocationLevel, c => c.MapFrom(p => p.Location.Level))
            .ForMember(p => p.LocationBuilding, c => c.MapFrom(p => p.Location.Building.Description))
            .ForMember(p => p.LocationZipCode, c => c.MapFrom(p => p.Location.Building.Address.ZipCode))
            .ForMember(p => p.LocationNumber, c => c.MapFrom(p => p.Location.Building.Address.Number))
            .ForMember(p => p.EventVector, c => c.MapFrom(p => p.MovimentType))
            .ForMember(p => p.EventDateTime, c => c.MapFrom(p => p.EventDateTime.ToString("dd/MM/yyyy HH:mm:ss")));

        CreateMap<Equipment, EquipmentDto>();
        CreateMap<Location, LocationDto>();
        CreateMap<Building, BuildingDto>();
        CreateMap<Address, AddressDto>();
        CreateMap<Sensor, SensorDto>();
    }
}
