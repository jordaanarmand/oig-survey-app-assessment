using Microsoft.EntityFrameworkCore;

namespace OIG.Survey.Data.Database;

public class DataDbContext : DbContext
{
    public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}