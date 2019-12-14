using System;
using System.ComponentModel;
using HyperSphere.Entities.Api.Interfaces.Entities;

namespace HyperSphere.Entities.Api.Impl.Entities
{
    public class BaseEntity : IEntity
    {
        public event PropertyChangedEventHandler PropertyChanged;
      
        public Guid Id { get; set; }
    }
}
