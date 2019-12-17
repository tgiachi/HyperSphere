using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public override int SaveChanges()
        {
            var changedEntities = ChangeTracker
                .Entries()
                .Where(_ => _.State == EntityState.Added || 
                            _.State == EntityState.Modified);

            var errors = new List<ValidationResult>(); // all errors are here
            foreach (var e in changedEntities)
            {
                var vc = new ValidationContext(e.Entity, null, null);
                Validator.TryValidateObject(
                    e.Entity, vc, errors, validateAllProperties: true);
            }

            if (errors.Count > 0)
                throw new ValidationException();

            return base.SaveChanges();
        }
     
    }
}
