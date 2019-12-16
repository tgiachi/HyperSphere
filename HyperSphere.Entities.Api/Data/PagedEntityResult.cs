using System;
using System.Collections.Generic;
using System.Text;
using HyperSphere.Entities.Api.Interfaces.Entities;

namespace HyperSphere.Entities.Api.Data
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
