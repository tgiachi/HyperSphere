using System;

namespace HyperSphere.Api.Core.Attributes.Dto
{

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class DtoMapperAttribute : Attribute
    {
        public Type EntityType { get; set; }
        public DtoMapperAttribute(Type entityType)
        {
            EntityType = entityType;
        }
    }
}
