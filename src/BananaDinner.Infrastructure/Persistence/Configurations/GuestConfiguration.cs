using BananaDinner.Domain.GuestAggregate;
using BananaDinner.Domain.GuestAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BananaDinner.Infrastructure.Persistence.Configurations;

public sealed class GuestConfigurations : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        ConfigureGuestsTable(builder);
    }

    private static void ConfigureGuestsTable(EntityTypeBuilder<Guest> builder)
    {
        builder
            .ToTable("Guests");

        builder
            .HasKey(g => g.Id);

        builder
            .Property(g => g.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => GuestId.Create(value));
    }
}
