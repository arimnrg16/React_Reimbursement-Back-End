using ExtCore.Data.Entities.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Entity : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }

        [Required]
        [MaxLength(64)]
        public string CreatedBy { get; set; }

        public DateTimeOffset? Modified { get; set; }

        [MaxLength(64)]
        public string ModifiedBy { get; set; }

    }

    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }

        DateTimeOffset? Deleted { get; set; }

        [MaxLength(64)]
        string DeleteBy { get; set; }
    }
}
