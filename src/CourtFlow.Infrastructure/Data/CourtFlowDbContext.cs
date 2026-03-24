using Microsoft.EntityFrameworkCore;

namespace CourtFlow.Infrastructure.Data;

public class CourtFlowDbContext(DbContextOptions<CourtFlowDbContext> options) :DbContext(options)
{
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourtFlowDbContext).Assembly);
    }
}