using Healthy.Core.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Database;

public class AppDbContext(IConfiguration configuration) : DbContext, IUnitOfWork
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(configuration.GetConnectionString("Database"));

        base.OnConfiguring(optionsBuilder);
    }
}
