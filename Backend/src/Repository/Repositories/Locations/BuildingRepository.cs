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

    public async Task<IEnumerable<Building>> GetAsync(int addressId)
    {
        return await Context.Buildings
            .Where(p => p.Address.Id == addressId)
            .ToListAsync();
    }
}