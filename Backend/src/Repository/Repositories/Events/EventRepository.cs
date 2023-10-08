using Domain.Entities.Events;
using Domain.Repositories.Dtos;
using Domain.Repositories.Events;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Repository.Repositories.Events;

public sealed class EventRepository : Repository<Event>, IEventRepository
{
    public EventRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<PageResponse<Event>> GetAsync(
        PageRequest pageRequest, int equipmentId = 0, int vectorId = 0,
        int addressId = 0, int buildingId = 0, int locationId = 0, int sensorId = 0, DateTime? startDatetime = null,
        DateTime? endDatetime = null)
    {
        var query = Get()
            .Include(p => p.Sensor)
            .Include(p => p.Equipment)
            .Include(p => p.Location)
            .ThenInclude(p => p.Building)
            .ThenInclude(p => p.Address)
            .AsQueryable();

        if (equipmentId != 0)
            query = query.Where(p => p.Equipment.Id == equipmentId);

        if (vectorId != 0)
            query = query.Where(p => (int)p.MovimentType == vectorId);

        if (sensorId != 0)
            query = query.Where(p => p.Sensor.Id == sensorId);
        else if (locationId != 0)
            query = query.Where(p => p.Location.Id == locationId);
        else if (buildingId != 0)
            query = query.Where(p => p.Location.Building.Id == buildingId);
        else if (addressId != 0)
            query = query.Where(p => p.Location.Building.Address.Id == addressId);

        if (startDatetime.HasValue)
            query = query.Where(p => p.EventDateTime >= startDatetime);
        if (endDatetime.HasValue)
            query = query.Where(p => p.EventDateTime <= endDatetime);

        var totalRows = await query.CountAsync();

        var entities = await query.Skip(pageRequest.GetRecordsCountToSkip())
            .Take(pageRequest.PageSize)
            .ToListAsync();

        return new(entities, pageRequest, totalRows);
    }
}