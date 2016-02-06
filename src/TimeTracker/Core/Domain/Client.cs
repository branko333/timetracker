namespace Preduzece.TimeTracker.Core.Domain
{
    public class Client : Entity
    {
        public string Name { get; set; }

        public int EmployerId { get; set; }

        public Employer Employer { get; set; }
    }
}
