using Domain.Entities.Sensors;
using Domain.Repositories.Dtos;

namespace Domain.Repositories.Sensors;

public interface ISensorRepository : IRepository<Sensor>
{
    Task<PageResponse<Sensor>> GetAsync(int locationId, PageRequest pageRequest);
}