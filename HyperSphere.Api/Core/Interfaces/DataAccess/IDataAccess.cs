using HyperSphere.Api.Core.Data.Entities;
using HyperSphere.Api.Core.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperSphere.Api.Core.Interfaces.DataAccess
{
    public interface IDataAccess<TEntity> where TEntity : class, IEntity
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

        PagedEntityResult<TEntity> PagedQuery(int pageSize, int pageNum, IQueryable<TEntity> query);
    }
}
