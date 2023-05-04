using Domain.Entities;

namespace Domain.Repositories
{
    public interface IReaderRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> Get();

        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity?> GetByIdAsync(int id);
    }
}
