using Domain.Entities.Locations;
using Domain.Repositories.Locations;
using Repository.Context;

namespace Repository.Repositories.Locations;

public sealed class LocationRepository : Repository<Location>, ILocationRepository
{
    public LocationRepository(ApplicationDbContext context) : base(context)
    {
    }
}
