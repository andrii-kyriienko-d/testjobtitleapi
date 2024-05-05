using Microsoft.EntityFrameworkCore;
using TestApiJobTitle.Domain.Entities;

namespace TestApiJobTitle.Persistence.Database;

public sealed class JobTitleDbContext : DbContext
{
    public JobTitleDbContext(DbContextOptions<JobTitleDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior =
            QueryTrackingBehavior.NoTracking;
        ChangeTracker.LazyLoadingEnabled = false;
    }

    public DbSet<JobTitle> JobTitles { get; set; }
}