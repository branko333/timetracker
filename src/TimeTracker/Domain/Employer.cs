using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Preduzece.TimeTracker.Domain
{
    [Table("Employers")]
    public class Employer : Entity
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public decimal DefaultHourRate { get; set; }

        public bool SendTimesheetEmail { get; set; }

        [Required]
        public string TimesheetEmailAddress { get; set; } = string.Empty;
    }
}
