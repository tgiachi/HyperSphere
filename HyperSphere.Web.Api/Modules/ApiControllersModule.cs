using Autofac;
using HyperSphere.Api.Core.Interfaces.Controllers;
using HyperSphere.Api.Core.Utils;

namespace HyperSphere.Web.Api.Modules
{
    public class ApiControllersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            AssemblyUtils.GetAppAssemblies().ForEach(a =>
            {
                builder
                    .RegisterAssemblyTypes(a)
                    .AsClosedTypesOf(typeof(IBaseApiController<,>))
                    .AsImplementedInterfaces().InstancePerDependency();
            });
            base.Load(builder);
        }
    }
}
