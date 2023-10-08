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
        PageRequest pageRequest,
        string rfTag = "",
        int locationId = 0)
    {
        var query = Get()
            .Include(p => p.Equipment)
            .Include(p => p.Location)
            .ThenInclude(p => p.Building)
            .ThenInclude(p => p.Address)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(rfTag))
            query = query.Where(p => p.Equipment.RfTag == rfTag);

        if (locationId != 0)
            query = query.Where(p => p.Location.Id == locationId);

        var totalRows = await query.CountAsync();

        var entities = await query.Skip(pageRequest.GetRecordsCountToSkip())
                          .Take(pageRequest.PageSize)
                          .ToListAsync();
        
        return new(entities, pageRequest, totalRows);
    }
}
