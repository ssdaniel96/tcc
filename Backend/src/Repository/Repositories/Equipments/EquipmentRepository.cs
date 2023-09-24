using Domain.Entities.Equipments;
using Domain.Repositories.Equipments;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Repository.Repositories.Equipments;

public sealed class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
{
    public EquipmentRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Equipment>> GetAsync(string? filter = null)
    {
        var query = Context.Equipments.AsQueryable();

        if (int.TryParse(filter, out var id))
            query = query.Where(p => p.Id == id
                                     || p.RFTag.Contains(id.ToString())
                                     || p.Description.Contains(id.ToString()));
        else if (!string.IsNullOrWhiteSpace(filter))
            query = query.Where(p => p.Description.Contains(filter)
                                     || p.RFTag.Contains(filter));

        return await query.ToListAsync();
    }

    public async Task<Equipment?> GetByRFTagAsync(string rfTag)
    {
        return await Context.Equipments.SingleOrDefaultAsync(p => p.RFTag == rfTag);
    }
}
