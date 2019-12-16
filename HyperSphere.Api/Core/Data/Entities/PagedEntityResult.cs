using HyperSphere.Api.Core.Interfaces.Entities;
using System.Collections.Generic;

namespace HyperSphere.Api.Core.Data.Entities
{
    public class PagedEntityResult<TEntity> where TEntity : IEntity
    {
        public List<TEntity> Result { get; set; }

        public int Count { get; set; }

        public int PageNum { get; set; }

        public int PageSize { get; set; }

        public int PageCount { get; set; }
    }
}
