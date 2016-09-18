using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Preduzece.TimeTracker.Domain
{
    [Table("Projects")]
    public class Project : Entity
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
