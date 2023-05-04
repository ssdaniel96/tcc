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

    public async Task<Equipment?> GetByRFTagAsync(string RFTag)
    {
        return await Context.Equipments.SingleOrDefaultAsync(p => p.RFTag == RFTag);
    }
}
