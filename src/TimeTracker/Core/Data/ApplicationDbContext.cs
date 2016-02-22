using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Preduzece.TimeTracker.Core.Domain;

namespace Preduzece.TimeTracker.Core.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }

        protected ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            InitializeConventions(builder);
            OverrideMappings(builder);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            FillAuditingInfo();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            FillAuditingInfo();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void FillAuditingInfo()
        {
            // TODO: Fix this to work with .NET Core...
            //var user = Thread.CurrentPrincipal.Identity.Name;
            var user = "TODO";
            var now = DateTime.Now;

            foreach (var entityEntry in ChangeTracker.Entries<Entity>())
            {
                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Entity.CreatedBy = user;
                    entityEntry.Entity.CreatedOn = now;
                    entityEntry.Entity.UpdatedBy = user;
                    entityEntry.Entity.UpdatedOn = now;
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Entity.UpdatedBy = user;
                    entityEntry.Entity.UpdatedOn = now;
                }
            }
        }

        private static void InitializeConventions(ModelBuilder builder)
        {
            // TODO: Investigate conventions
        }

        private static void OverrideMappings(ModelBuilder builder)
        {
            builder.Entity<TimesheetEntry>()
                .HasOne(x => x.Project)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict); // TODO: This does not look right!
        }
    }
}
