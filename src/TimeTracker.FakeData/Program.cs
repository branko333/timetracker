using Bogus;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Preduzece.TimeTracker.Core.Data;
using Preduzece.TimeTracker.Core.Domain;

namespace Preduzece.TimeTracker.FakeData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            var configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(configuration["Data:DefaultConnection:ConnectionString"]);
            var context = new ApplicationDbContext(optionsBuilder.Options);

            var employerFaker = new Faker<Employer>()
                .RuleFor(x => x.Name, f => f.Company.CompanyName())
                .RuleFor(x => x.DefaultHourRate, f => f.Random.Number(5, 50))
                .RuleFor(x => x.SendTimesheetEmail, f => f.Random.Bool())
                .RuleFor(x => x.TimesheetEmailAddress, f => f.Internet.Email())
                .RuleFor(x => x.CreatedBy, f => f.Internet.UserName())
                .RuleFor(x => x.CreatedOn, f => f.Date.Recent())
                .RuleFor(x => x.UpdatedBy, f => f.Internet.UserName())
                .RuleFor(x => x.UpdatedOn, f => f.Date.Recent());

            var employers = employerFaker.Generate(3);

            context.Employers.AddRange(employers);
            context.SaveChanges();
        }
    }
}
