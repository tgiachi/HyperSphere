using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using HyperSphere.Api.Core.Engine;
using HyperSphere.Api.Core.Interfaces.DataAccess;
using HyperSphere.Entities.Api.Impl.DataAccess;
using HyperSphere.Web.Test.App.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HyperSphere.Web.Test.App
{
    public class Startup
    {

        public ILifetimeScope AutofacContainer { get; private set; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TestApplicationDbContext>(options => options.UseInMemoryDatabase("test"));
            services.AddSingleton<TestApplicationDbContext>();

            services.AddOptions();
            services.AddControllers();

            services.AddSwaggerDocument();
        }


        public void ConfigureContainer(ContainerBuilder builder)
        {
            HyperSphereEngine.Instance.ScanModules().ForEach(m =>
            {
                builder.RegisterModule(m);
            });

            builder.RegisterType<TestApplicationDbContext>().As<DbContext>().InstancePerDependency();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            var context = AutofacContainer.Resolve<TestApplicationDbContext>();

            context.Database.EnsureCreated();

            var dao = AutofacContainer.Resolve<IDataAccess<TestModel>>();

            dao.Insert(new TestModel()
            {
                TestValue = "OK"
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
