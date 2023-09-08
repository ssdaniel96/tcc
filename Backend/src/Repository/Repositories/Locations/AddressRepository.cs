using Domain.Entities.Locations;
using Domain.Repositories.Locations;
using Repository.Context;

namespace Repository.Repositories.Locations;

public class AddressRepository : Repository<Address>, IAddressRepository
{
    public AddressRepository(ApplicationDbContext context) : base(context)
    {
    }
}