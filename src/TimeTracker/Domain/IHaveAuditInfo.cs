using System;

namespace Preduzece.TimeTracker.Domain
{
    public interface IHaveAuditInfo
    {
        DateTime CreatedOn { get; set; }
        string CreatedBy { get; set; }
        DateTime UpdatedOn { get; set; }
        string UpdatedBy { get; set; }
    }
}
