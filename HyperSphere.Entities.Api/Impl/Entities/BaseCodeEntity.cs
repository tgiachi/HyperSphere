using System.ComponentModel.DataAnnotations;
using HyperSphere.Entities.Api.Interfaces.Entities;

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
