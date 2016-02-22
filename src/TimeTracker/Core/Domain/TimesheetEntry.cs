using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Preduzece.TimeTracker.Core.Domain
{
    [Table("TimesheetEntries")]
    public class TimesheetEntry : Entity
    {
        [MaxLength]
        public string Description { get; set; }

        [Range(0, 24)]
        public decimal Hours { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal HourRate { get; set; }

        public int TimesheetId { get; set; }
        public Timesheet Timesheet { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
