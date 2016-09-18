using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Preduzece.TimeTracker.Domain
{
    [Table("Clients")]
    public class Client : Entity
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public int EmployerId { get; set; }

        public Employer Employer { get; set; }
    }
}
