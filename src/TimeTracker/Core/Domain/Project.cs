using System.ComponentModel.DataAnnotations;

namespace Preduzece.TimeTracker.Core.Domain
{
    public class Project : Entity
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
