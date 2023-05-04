using Domain.Entities;
using Domain.Repositories;
using Repository.Context;

namespace Repository.Repositories;

public abstract class Repository<TEntity> : ReaderRepository<TEntity>,
    IRepository<TEntity> where TEntity : Entity
{
    protected Repository(ApplicationDbContext context) : base(context)
    {
    }

    public virtual async Task<TEntity> InsertAsync(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task RemoveAsync(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        await Context.SaveChangesAsync();
    }

    public virtual async Task<TEntity> SaveAsync(TEntity entity)
    {
        if (entity.Id != 0)
            return await UpdateAsync(entity);

        return await InsertAsync(entity);
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
        await Context.SaveChangesAsync();
        return entity;
    }
}
