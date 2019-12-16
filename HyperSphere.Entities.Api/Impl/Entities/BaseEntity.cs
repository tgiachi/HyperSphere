using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using HyperSphere.Entities.Api.Interfaces.Entities;

namespace HyperSphere.Entities.Api.Impl.Entities
{
    public class BaseEntity : IEntity
    {
        public event PropertyChangedEventHandler PropertyChanged;
      

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }


        public override string ToString()
        {
            return $"{Id}";
        }
    }
}
