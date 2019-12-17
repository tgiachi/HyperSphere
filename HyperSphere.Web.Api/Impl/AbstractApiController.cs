using System;
using HyperSphere.Api.Core.Interfaces.Controllers;
using HyperSphere.Api.Core.Interfaces.DataAccess;
using HyperSphere.Api.Core.Interfaces.Dto;
using HyperSphere.Api.Core.Interfaces.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HyperSphere.Web.Api.Impl
{
    public abstract class AbstractApiController<TEntity, TDto> :  IBaseApiController<TEntity, TDto> where TEntity : class, IEntity where TDto : IDtoEntity
    {
        protected ILogger Logger { get; }
        public IDataAccess<TEntity> Dao { get; set; }
        public IDtoMapper<TEntity, TDto> Mapper { get; set; }

        protected AbstractApiController(ILogger<IBaseApiController<TEntity, TDto>> logger, IDataAccess<TEntity> dao, IDtoMapper<TEntity, TDto> mapper)
        {
            Logger = logger;
            Dao = dao;
            Mapper = mapper;
        }

        [HttpGet("findAll")]
        public virtual ActionResult<List<TDto>> FindAll()
        {
            return Mapper.ToDto(Dao.FindAll());
        }

        [HttpGet("findById/{guid}")]
        public ActionResult<TDto> FindById(Guid guid)
        {
            return Mapper.ToDto(Dao.FindById(guid));
        }


        [HttpPost("insert")]
        public ActionResult<TDto> Insert([FromBody] TDto dto)
        {
            return Mapper.ToDto(Dao.Insert(Mapper.ToEntity(dto)));

        }
    }
}
