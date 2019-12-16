using Autofac;
using AutoMapper;
using HyperSphere.Api.Core.Attributes.Dto;
using HyperSphere.Api.Core.Attributes.Modules;
using HyperSphere.Api.Core.Data.Dto;
using HyperSphere.Api.Core.Interfaces.Dto;
using HyperSphere.Api.Core.Utils;
using HyperSphere.Entities.Api.Impl.Dto;
using System.Collections.Generic;
using System.Reflection;
using Module = Autofac.Module;

namespace HyperSphere.Entities.Api.Modules
{
    [RegistrationModule]
    public class AutoMapperModule : Module
    {
        private readonly List<DtoMapObject> _mapping = new List<DtoMapObject>();
        protected override void Load(ContainerBuilder builder)
        {
            AssemblyUtils.GetAttribute<DtoMapperAttribute>().ForEach(t =>
            {
                var attr = t.GetCustomAttribute<DtoMapperAttribute>();
                _mapping.Add(new DtoMapObject()
                {
                    Source = t,
                    Destination = attr.EntityType
                });
            });

            builder.Register<IConfigurationProvider>(ctx => new MapperConfiguration(cfg =>
            {
                _mapping.ForEach(map => { cfg.CreateMap(map.Source, map.Destination).ReverseMap(); });
            }));

            builder.Register<IMapper>(ctx => new Mapper(ctx.Resolve<IConfigurationProvider>(), ctx.Resolve)).InstancePerDependency();

            builder.RegisterGeneric(typeof(AbstractDtoMapper<,>)).As(typeof(IDtoMapper<,>)).InstancePerDependency();

            base.Load(builder);
        }
    }
}
