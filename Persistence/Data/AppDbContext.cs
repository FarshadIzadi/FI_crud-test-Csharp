using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now; break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now; break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
