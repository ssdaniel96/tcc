using Domain.Entities.Equipments;

namespace Domain.Repositories.Equipments;

public interface IEquipmentRepository : IRepository<Equipment>
{
    Task<IEnumerable<Equipment>> GetAsync(string? filter = null);
    Task<Equipment?> GetByRFTagAsync(string RFTag);
}
