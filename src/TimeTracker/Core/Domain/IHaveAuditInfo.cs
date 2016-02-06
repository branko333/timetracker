using System;

namespace Preduzece.TimeTracker.Core.Domain
{
    public interface IHaveAuditInfo
    {
        DateTime CreatedOn { get; set; }
        string CreatedBy { get; set; }
        DateTime UpdatedOn { get; set; }
        string UpdatedBy { get; set; }
    }
}
