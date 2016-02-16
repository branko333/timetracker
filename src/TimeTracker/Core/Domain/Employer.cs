namespace Preduzece.TimeTracker.Core.Domain
{
    public class Employer : Entity
    {
        public string Name { get; set; }

        public decimal DefaultHourRate { get; set; }

        public bool SendTimesheetEmail { get; set; }

        public string TimesheetEmailAddress { get; set; }
    }
}
