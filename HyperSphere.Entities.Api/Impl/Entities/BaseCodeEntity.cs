using HyperSphere.Api.Core.Interfaces.Entities;
using System.ComponentModel.DataAnnotations;

namespace HyperSphere.Entities.Api.Impl.Entities
{
    public class BaseCodeEntity : BaseEntity, ICodeEntity
    {
        [MaxLength(10)]
        public string Code { get; set; }


        public override string ToString()
        {
            return $"{Id} - {Code}";
        }
    }
}
