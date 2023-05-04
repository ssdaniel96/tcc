using Domain.Entities.Equipments;

namespace Domain.Repositories.Equipments;

public interface IEquipmentRepository : IRepository<Equipment>
{
    Task<Equipment?> GetByRFTagAsync(string RFTag);
}
