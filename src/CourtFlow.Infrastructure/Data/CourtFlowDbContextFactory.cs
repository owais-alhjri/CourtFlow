using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
namespace CourtFlow.Infrastructure.Data;

public class CourtFlowDbContextFactory : IDesignTimeDbContextFactory<CourtFlowDbContext>
{
    public CourtFlowDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<CourtFlowDbContext>();
        optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));

        return new CourtFlowDbContext(optionsBuilder.Options);
    }
}