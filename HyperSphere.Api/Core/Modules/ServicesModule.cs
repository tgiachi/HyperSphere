using Autofac;
using HyperSphere.Api.Core.Attributes.Modules;
using HyperSphere.Api.Core.Attributes.Services;
using HyperSphere.Api.Core.Utils;
using System;
using System.Collections.Generic;

namespace HyperSphere.Api.Core.Modules
{
    [RegistrationModule]
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            var singletonServices = new List<Type>();

            AssemblyUtils.GetAttribute<SingletonServiceAttribute>().ForEach(singletonServices.Add);


            singletonServices.ForEach(ss =>
            {
                var asInterface = AssemblyUtils.GetInterfaceOfType(ss);

                if (asInterface != null)
                {
                    builder.RegisterType(ss).As(asInterface).InstancePerLifetimeScope();
                }
                else
                {
                    builder.RegisterType(ss).AsSelf().InstancePerLifetimeScope();
                }

            });

            base.Load(builder);
        }
    }
}
