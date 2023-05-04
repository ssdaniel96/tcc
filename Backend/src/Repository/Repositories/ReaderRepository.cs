using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Repository.Repositories;

public abstract class ReaderRepository<TEntity> : IReaderRepository<TEntity> where TEntity : Entity
{
    protected readonly ApplicationDbContext Context;

    protected ReaderRepository(ApplicationDbContext context)
    {
        Context = context;
    }

    public virtual IQueryable<TEntity> Get() => Context.Set<TEntity>().AsQueryable();

    public virtual async Task<IEnumerable<TEntity>> GetAsync()
        => await Context.Set<TEntity>().ToListAsync();

    public virtual async Task<TEntity?> GetByIdAsync(int id)
        => await Context.Set<TEntity>().Where(p => p.Id == id).SingleOrDefaultAsync();
}