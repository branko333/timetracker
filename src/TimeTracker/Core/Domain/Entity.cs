using System;

namespace Preduzece.TimeTracker.Core.Domain
{
    public abstract class Entity : IHaveAuditInfo
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
