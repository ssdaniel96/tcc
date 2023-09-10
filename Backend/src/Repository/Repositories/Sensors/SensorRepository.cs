using Domain.Entities.Sensors;
using Domain.Repositories.Sensors;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Repository.Repositories.Sensors;

public class SensorRepository : Repository<Sensor>, ISensorRepository
{
    public SensorRepository(ApplicationDbContext context) : base(context)
    {

    }
    
    public async Task<IEnumerable<Sensor>> GetAsync(int locationId)
    {
        var entities = await Context.Sensors
            .Include(p => p.Location)
            .Where(p => p.Location.Id == locationId)
            .ToListAsync();

        return entities;
    }
}