using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HyperSphere.Api.Core.Interfaces.Controllers;
using HyperSphere.Api.Core.Interfaces.DataAccess;
using HyperSphere.Api.Core.Interfaces.Dto;
using HyperSphere.Web.Api.Impl;
using HyperSphere.Web.Test.App.Dao;
using HyperSphere.Web.Test.App.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HyperSphere.Web.Test.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestModelController : AbstractApiController<TestModel, TestModelDao>
    {
        public TestModelController(ILogger<IBaseApiController<TestModel, TestModelDao>> logger, IDataAccess<TestModel> dao, IDtoMapper<TestModel, TestModelDao> mapper) : base(logger, dao, mapper)
        {
        }
    }
}
