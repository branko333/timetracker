using System.ComponentModel.DataAnnotations;

namespace Preduzece.TimeTracker.Core.Domain
{
    public class TimesheetEntry : Entity
    {
        [MaxLength]
        public string Description { get; set; }

        public decimal Hours { get; set; }

        public decimal HourRate { get; set; }

        public int TimesheetId { get; set; }
        public Timesheet Timesheet { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
