using Domain.Entities.Locations;
using Domain.Repositories.Dtos;

namespace Domain.Repositories.Locations;

public interface ILocationRepository : IRepository<Location>
{
    Task<PageResponse<Location>> GetAsync(PageRequest pageRequest);
}
