using System;
using System.ComponentModel.DataAnnotations;

namespace Preduzece.TimeTracker.Domain
{
    public abstract class Entity : IHaveAuditInfo
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        [Required]
        public string UpdatedBy { get; set; }
    }
}
