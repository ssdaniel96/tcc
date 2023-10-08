using Domain.Entities.Sensors;
using Domain.Repositories.Dtos;
using Domain.Repositories.Sensors;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Repository.Repositories.Sensors;

public class SensorRepository : Repository<Sensor>, ISensorRepository
{
    public SensorRepository(ApplicationDbContext context) : base(context)
    {

    }
    
    public async Task<PageResponse<Sensor>> GetAsync(int locationId, PageRequest pageRequest)
    {
        var query = Context.Sensors
            .Include(p => p.Location)
            .Where(p => p.Location.Id == locationId);
        
        var totalRows = await query.CountAsync();
        
        var pagedResult = await query
            .Skip(pageRequest.GetRecordsCountToSkip())
            .Take(pageRequest.PageSize)
            .ToListAsync();

        return new(pagedResult, pageRequest.PageNumber, totalRows, pageRequest.PageSize);
    }

    public override async Task<Sensor?> GetByIdAsync(int id)
    {
        var entity = await Context.Sensors
            .Include(p => p.Location)
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();

        return entity;
    }
}