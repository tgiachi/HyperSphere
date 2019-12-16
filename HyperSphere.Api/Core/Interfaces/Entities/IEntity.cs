using System;
using System.ComponentModel;

namespace HyperSphere.Api.Core.Interfaces.Entities
{
    public interface IEntity : INotifyPropertyChanged
    {
        Guid Id { get; set; }
    }
}
