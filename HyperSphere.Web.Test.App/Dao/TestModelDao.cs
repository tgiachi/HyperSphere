using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HyperSphere.Api.Core.Attributes.Dto;
using HyperSphere.Api.Core.Interfaces.DataAccess;
using HyperSphere.Web.Test.App.Model;

namespace HyperSphere.Web.Test.App.Dao
{
    [DtoMapper(typeof(TestModel))]
    public class TestModelDao : IDtoEntity
    {
        public Guid Id { get; set; }

        public string TestValue { get; set; }
    }
}
