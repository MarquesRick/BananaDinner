using BananaDinner.Domain.MenuAggregate;
using Microsoft.EntityFrameworkCore;

namespace BananaDinner.Infrastructure.Persistence;

public class BananaDinnerDbContext : DbContext
{
    public BananaDinnerDbContext(DbContextOptions<BananaDinnerDbContext> options)
    : base(options)
    {
    }

    public DbSet<Menu> Menus { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(BananaDinnerDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
