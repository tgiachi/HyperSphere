using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HyperSphere.Entities.Api.Interfaces.Entities;

namespace HyperSphere.Entities.Api.Interfaces.DataAccess
{
    public interface IDataAccess<TEntity> where TEntity : IEntity
    {
        long Count();
        Task<long> CountAsync();

        List<TEntity> FindAll();

        TEntity FindById(Guid id);

        Task<List<TEntity>> FindAllAsync();

        TEntity Insert(TEntity entity);

        Task<TEntity> InsertAsync(TEntity entity);

        TEntity Update(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        bool Delete(Func<TEntity, bool> query);

        bool Delete(TEntity entity);

        List<TEntity> Query(Func<TEntity, bool> query);
    }
}
