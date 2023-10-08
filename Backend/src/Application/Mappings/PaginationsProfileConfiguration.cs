﻿using Application.UseCases.Locations.Dtos;
using AutoMapper;
using Domain.Entities.Locations;
using Domain.Entities.Sensors;
using Domain.Repositories.Dtos;

namespace Application.Mappings;

public class PaginationsProfileConfiguration : Profile
{
    public PaginationsProfileConfiguration()
    {
        CreateMap<PageResponse<Location>, PageResponse<LocationDto>>();
        CreateMap<PageResponse<Sensor>, PageResponse<SensorDto>>();
    }
}