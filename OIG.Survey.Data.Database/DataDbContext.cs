using Microsoft.EntityFrameworkCore;
using OIG.Survey.Data.Database.Entities;

namespace OIG.Survey.Data.Database;

public class DataDbContext : DbContext
{
    public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataDbContext).Assembly);

        modelBuilder.Entity<QuestionnaireStatus>().HasData(new QuestionnaireStatus[]
        {
            new () { Id = 1, Name = "Concept" },
            new () { Id = 2, Name = "Scheduled" },
            new () { Id = 3, Name = "Active" },
            new () { Id = 4, Name = "Finished" }
        });
        base.OnModelCreating(modelBuilder);
    }
}