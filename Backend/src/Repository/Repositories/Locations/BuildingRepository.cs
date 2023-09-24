using Domain.Entities.Locations;
using Domain.Repositories.Locations;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Repository.Repositories.Locations;

public class BuildingRepository : Repository<Building>, IBuildingRepository
{
    public BuildingRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Building>> GetAsync(int addressId, string? filter = null)
    {
        
        var query = Context.Buildings
            .Include(p => p.Address)
            .AsQueryable();

        if (addressId == 0)
            query = query.Where(p => p.AddressId == addressId);

        if (int.TryParse(filter, out var id))
            query = query.Where(p => p.Id == id
                                || p.Description.Contains(id.ToString()));
        else if (!string.IsNullOrWhiteSpace(filter))
            query = query.Where(p => p.Description.Contains(filter));

        return await query.ToListAsync();
        
        
    }
}