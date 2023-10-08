using Domain.Entities.Events;
using Domain.Repositories.Dtos;

namespace Domain.Repositories.Events;

public interface IEventRepository : IRepository<Event>
{
    Task<PageResponse<Event>> GetAsync(PageRequest pageRequest, string RfTag = "", int locationId = 0);
}
