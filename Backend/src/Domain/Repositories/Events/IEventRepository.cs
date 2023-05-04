using Domain.Entities.Events;

namespace Domain.Repositories.Events;

public interface IEventRepository : IRepository<Event>
{
    Task<IEnumerable<Event>> GetAsync(string RFTag = "", int locationId, int page = 1, int size = 25);
}
