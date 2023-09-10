using Domain.Entities.Locations;
using Domain.Repositories.Dtos;
using Domain.Repositories.Locations;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Repository.Repositories.Locations;

public sealed class LocationRepository : Repository<Location>, ILocationRepository
{
    public LocationRepository(ApplicationDbContext context) : base(context)
    {
        
    }


    public async Task<PageResponse<Location>> GetAsync(PageRequest pageRequest)
    {
        var skipRecords = pageRequest.GetRecordsCountToSkip();
        var entities = await Context.Locations
            .Include(p => p.Building)
            .ThenInclude(p => p.Address)
            .Skip(skipRecords)
            .Take(pageRequest.PageSize)
            .ToListAsync();

        var totalRows = await Context.Locations.CountAsync();
        
        return new(entities, pageRequest.PageNumber, totalRows, pageRequest.PageSize);
    }
}
