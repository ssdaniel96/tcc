﻿using Domain.Entities;

namespace Domain.Repositories;

public interface IRepository<TEntity> : IReaderRepository<TEntity> where TEntity : Entity
{
    Task RemoveAsync(TEntity entity);

    Task<TEntity> InsertAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> SaveAsync(TEntity entity);
}
