using Domain.Entities.Locations;

namespace Domain.Repositories.Locations;

public interface IBuildingRepository : IRepository<Building>
{
    Task<IEnumerable<Building>> GetAsync(int addressId, string? filter = null);
}