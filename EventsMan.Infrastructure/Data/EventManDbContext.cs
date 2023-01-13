using EventsMan.Domain.Common;
using EventsMan.Domain.Entities;
using EventsMan.Infrastructure.Data.SeedData;
using Microsoft.EntityFrameworkCore;

namespace EventsMan.Infrastructure.Data;

public class EventManDbContext : DbContext
{
    public EventManDbContext(DbContextOptions<EventManDbContext> opts) : base(opts)
    {
        
    }
    
    public DbSet<Event> Events { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventManDbContext).Assembly);
        new DbInitializer(modelBuilder).SeedData();
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntries>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}