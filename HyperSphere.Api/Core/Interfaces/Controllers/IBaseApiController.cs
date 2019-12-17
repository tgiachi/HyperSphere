using System;
using HyperSphere.Api.Core.Interfaces.DataAccess;
using HyperSphere.Api.Core.Interfaces.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace HyperSphere.Api.Core.Interfaces.Controllers
{
    public interface IBaseApiController<TEntity, TDto> where TEntity : class, IEntity where TDto : IDtoEntity
    {
        ActionResult<List<TDto>> FindAll();

        ActionResult<TDto> FindById(Guid guid);


        ActionResult<TDto> Insert(TDto dto);
    }
}
