using HyperSphere.Api.Core.Interfaces.Entities;
using System;
using System.Collections.ObjectModel;

namespace HyperSphere.Api.Core.Interfaces.Repository
{
    public interface IDataRepository<TEntity> where TEntity : IEntity
    {
        IObservable<int> Count { get; set; }

        ObservableCollection<TEntity> Items { get; set; }

        IObservable<TEntity> SelectedItem { get; set; }
    }
}
