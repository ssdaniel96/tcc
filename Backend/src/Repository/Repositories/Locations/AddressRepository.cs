using Domain.Entities.Locations;
using Domain.Repositories.Locations;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Repository.Repositories.Locations;

public class AddressRepository : Repository<Address>, IAddressRepository
{
    public AddressRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Address>> GetAsync(string? filter = null)
    {
        var query = Context.Addresses.AsQueryable();

        if (int.TryParse(filter, out var id))
            query = query.Where(p => p.Id == id 
                                    || p.Number == filter.ToString()
                                    || p.ZipCode == filter.ToString());
        else if (!string.IsNullOrWhiteSpace(filter))
            query = query.Where(p => p.ZipCode == filter
                                     || p.Number == filter);

        return await query.ToListAsync();
    }
}