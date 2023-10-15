using Domain.Entities.Events;
using Domain.Repositories.Dtos;

namespace Domain.Repositories.Events;

public interface IEventRepository : IRepository<Event>
{
    Task<PageResponse<Event>> GetAsync(PageRequest pageRequest, int equipmentId = 0, int vectorId = 0,
        int addressId = 0, int buildingId = 0, int locationId = 0, int sensorId = 0, DateTime? startDatetime = null,
        DateTime? endDatetime = null);
}