using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HyperSphere.Entities.Api.Impl.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HyperSphere.Web.Test.App.Model
{
    public class TestApplicationDbContext : DbContext
    {
        public DbSet<TestModel> TestModels { get; set; }


        public TestApplicationDbContext(DbContextOptions<TestApplicationDbContext> options) : base(options)
        {

        }

     
    }
}
