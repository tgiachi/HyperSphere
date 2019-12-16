using AutoMapper;
using HyperSphere.Api.Core.Interfaces.DataAccess;
using HyperSphere.Api.Core.Interfaces.Dto;
using HyperSphere.Api.Core.Interfaces.Entities;
using System.Collections.Generic;
using System.Linq;

namespace HyperSphere.Entities.Api.Impl.Dto
{
    public class AbstractDtoMapper<TEntity, TDto> : IDtoMapper<TEntity, TDto> where TEntity : IEntity where TDto : IDtoEntity
    {
        private readonly IMapper _mapper;
        public AbstractDtoMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TEntity ToEntity(TDto dto)
        {
            return _mapper.Map<TEntity>(dto);
        }

        public List<TEntity> ToEntity(List<TDto> entities)
        {
            return entities.Select(ToEntity).ToList();
        }

        public TDto ToDto(TEntity entity)
        {
            return _mapper.Map<TDto>(entity);
        }

        public List<TDto> ToDto(List<TEntity> entities)
        {
            return entities.Select(ToDto).ToList();
        }
    }
}
