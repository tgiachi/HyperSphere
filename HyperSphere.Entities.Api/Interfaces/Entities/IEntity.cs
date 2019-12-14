using System;
using System.ComponentModel;

namespace HyperSphere.Entities.Api.Interfaces.Entities
{
    public interface IEntity : INotifyPropertyChanged
    {
        Guid Id { get; set; }
    }
}
