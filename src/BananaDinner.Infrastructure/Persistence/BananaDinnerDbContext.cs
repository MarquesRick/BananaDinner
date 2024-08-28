using BananaDinner.Domain.BillAggregate;
using BananaDinner.Domain.DinnerAggregate;
using BananaDinner.Domain.GuestAggregate;
using BananaDinner.Domain.HostAggregate;
using BananaDinner.Domain.MenuAggregate;
using BananaDinner.Domain.MenuReviewAggregate;
using BananaDinner.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace BananaDinner.Infrastructure.Persistence;

public class BananaDinnerDbContext : DbContext
{
    public BananaDinnerDbContext(DbContextOptions<BananaDinnerDbContext> options)
    : base(options)
    {
    }

    public DbSet<Bill> Bills { get; set; } = null!;
    public DbSet<Dinner> Dinners { get; set; } = null!;
    public DbSet<Guest> Guests { get; set; } = null!;
    public DbSet<Host> Hosts { get; set; } = null!;
    public DbSet<Menu> Menus { get; set; } = null!;
    public DbSet<MenuReview> MenuReviews { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(BananaDinnerDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
