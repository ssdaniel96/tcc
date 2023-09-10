using Domain.Entities.Sensors;

namespace Domain.Repositories.Sensors;

public interface ISensorRepository : IRepository<Sensor>
{
    Task<IEnumerable<Sensor>> GetAsync(int locationId);
}