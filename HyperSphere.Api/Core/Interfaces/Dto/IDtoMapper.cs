using HyperSphere.Api.Core.Interfaces.DataAccess;
using HyperSphere.Api.Core.Interfaces.Entities;
using System.Collections.Generic;

namespace HyperSphere.Api.Core.Interfaces.Dto
{
    public interface IDtoMapper<TEntity, TDto> where TEntity : IEntity where TDto : IDtoEntity
    {
        TEntity ToEntity(TDto dto);

        List<TEntity> ToEntity(List<TDto> entities);

        TDto ToDto(TEntity entity);

        List<TDto> ToDto(List<TEntity> entities);
    }
}
