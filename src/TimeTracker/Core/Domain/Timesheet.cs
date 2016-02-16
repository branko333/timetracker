using System;
using System.Collections.Generic;

namespace Preduzece.TimeTracker.Core.Domain
{
    public class Timesheet : Entity
    {
        public DateTime Date { get; set; }

        public int DeveloperId { get; set; }

        public ICollection<TimesheetEntry> Entries { get; set; } = new List<TimesheetEntry>();

        public TimesheetEntry AddEntry(TimesheetEntry entry)
        {
            entry.TimesheetId = Id;
            entry.Timesheet = this;
            Entries.Add(entry);

            return entry;
        }
    }
}
