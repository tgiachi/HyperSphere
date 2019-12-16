using System;
using System.Collections.Generic;
using Autofac;
using HyperSphere.Api.Core.Attributes.Modules;
using HyperSphere.Api.Core.Utils;

namespace HyperSphere.Api.Core.Engine
{
    public class HyperSphereEngine
    {
        private static HyperSphereEngine _instance;

        public static HyperSphereEngine Instance => _instance ?? (_instance = new HyperSphereEngine());

        public List<Module> ScanModules()
        {
            var result = new List<Module>();

            AssemblyUtils.GetAttribute<RegistrationModuleAttribute>().ForEach(m =>
            {
                var module = (Module)Activator.CreateInstance(m);

                result.Add(module);
            });

            return result;
        }

    }
}
