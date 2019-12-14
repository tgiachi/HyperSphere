using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperSphere.Entities.Api.Interfaces.Entities;

namespace HyperSphere.Entities.Api.Interfaces.Repository
{
    public interface IDataRepository<TEntity> where TEntity : IEntity
    {
        IObservable<int> Count { get; set; }

        ObservableCollection<TEntity> Items { get; set; }

        IObservable<TEntity> SelectedItem { get; set; }
    }
}
