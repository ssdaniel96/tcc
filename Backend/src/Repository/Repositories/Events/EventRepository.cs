using Domain.Entities.Events;
using Domain.Repositories.Events;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Repository.Repositories.Events;

public sealed class EventRepository : Repository<Event>, IEventRepository
{
    public EventRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Event>> GetAsync(
        string RFTag = "",
        int locationId = 0,
        int page = 1,
        int size = 25)
    {
        var query = Get();

        if (!string.IsNullOrWhiteSpace(RFTag))
            query = query.Where(p => p.Equipment.RFTag == RFTag);

        if (locationId != 0)
            query = query.Where(p => p.Location.Id == locationId);

        return await query.Skip((page - 1) * size)
                          .Take(size)
                          .ToListAsync();
    }
}
