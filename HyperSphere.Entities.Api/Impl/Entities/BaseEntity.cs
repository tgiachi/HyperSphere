using HyperSphere.Api.Core.Interfaces.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HyperSphere.Entities.Api.Impl.Entities
{
    public class BaseEntity : IEntity
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }


        public override string ToString()
        {
            return $"{Id}";
        }
    }
}
