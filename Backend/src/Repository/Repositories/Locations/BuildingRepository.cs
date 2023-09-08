using Domain.Entities.Locations;
using Domain.Repositories.Locations;
using Repository.Context;

namespace Repository.Repositories.Locations;

public class BuildingRepository : Repository<Building>, IBuildingRepository
{
    public BuildingRepository(ApplicationDbContext context) : base(context)
    {
    }
}