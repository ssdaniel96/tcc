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


    public async Task<PageResponse<Location>> GetAsync(
        PageRequest pageRequest, 
        int buildingId = 0, 
        string? filter = null)
    {
        var skipRecords = pageRequest.GetRecordsCountToSkip();
        
        var query = Context.Locations
            .Include(p => p.Building)
            .ThenInclude(p => p.Address)
            .AsQueryable();

        if (buildingId != 0)
            query = query.Where(p => p.Building.Id == buildingId);
        
        if (int.TryParse(filter, out var id))
            query = query.Where(p => p.Id == id);
        else if (!string.IsNullOrWhiteSpace(filter))
            query = query.Where(p => p.Level.Contains(filter)
                                     || p.Description.Contains(filter));

        var entities = await query.Skip(skipRecords)
            .Take(pageRequest.PageSize)
            .ToListAsync();

        var totalRows = await Context.Locations.CountAsync();

        return new(entities, pageRequest.PageNumber, totalRows, pageRequest.PageSize);
    }
}