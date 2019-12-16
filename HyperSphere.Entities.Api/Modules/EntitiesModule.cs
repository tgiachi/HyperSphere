using Autofac;
using HyperSphere.Api.Core.Attributes.Modules;
using HyperSphere.Api.Core.Interfaces.DataAccess;
using HyperSphere.Entities.Api.Impl.DataAccess;

namespace HyperSphere.Entities.Api.Modules
{
    [RegistrationModule]
    public class EntitiesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(AbstractDataAccess<>)).As(typeof(IDataAccess<>)).InstancePerDependency();

            base.Load(builder);
        }
    }
}
