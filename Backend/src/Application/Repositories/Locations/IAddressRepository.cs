using Domain.Entities.Locations;

namespace Domain.Repositories.Locations;

public interface IAddressRepository : IRepository<Address>
{
    Task<IEnumerable<Address>> GetAsync(string? filter = null);
}