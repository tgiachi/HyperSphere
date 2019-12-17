using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HyperSphere.Entities.Api.Impl.Entities;

namespace HyperSphere.Web.Test.App.Model
{
    public class TestModel : BaseEntity
    {

        [Required]
        public string TestValue { get; set; }
    }
}
