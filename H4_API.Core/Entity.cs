using System;
using System.ComponentModel.DataAnnotations;

namespace H4_API.Core
{
    public class Entity : IEntity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        [Key, Required]
        public Guid Id { get; set; }
    }
}
