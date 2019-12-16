using HyperSphere.Api.Core.Interfaces.DataAccess;
using HyperSphere.Api.Core.Interfaces.Entities;
using System.Collections.Generic;

namespace HyperSphere.Api.Core.Interfaces.Controllers
{
    public interface IBaseApiController<TEntity, TDto> where TEntity : class, IEntity where TDto : IDtoEntity
    {

        List<TDto> FindAll();
    }
}
