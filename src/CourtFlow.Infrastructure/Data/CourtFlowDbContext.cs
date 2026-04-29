using CourtFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourtFlow.Infrastructure.Data;

public class CourtFlowDbContext(DbContextOptions<CourtFlowDbContext> options) :DbContext(options)
{
 
    public DbSet<User> Users { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<MaintenanceWindow> MaintenanceWindows { get; set; }
    public DbSet<PricingRule> PricingRules { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Waitlist> Waitlists { get; set; }
    public DbSet<Court> Courts { get; set; } 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourtFlowDbContext).Assembly);
    }
}