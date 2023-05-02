using Domain.Entities.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Locations;

internal sealed class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Description)
            .HasMaxLength(100)
            .HasColumnType("varchar")
            .IsRequired();

        builder.Property(p => p.Level)
            .HasMaxLength(10)
            .HasColumnType("varchar")
            .IsRequired();

        builder.HasOne(p => p.Building)
            .WithMany()
            .HasForeignKey("BuildingId")
            .IsRequired();

        builder.ToTable(nameof(Location), schema: "locations");
    }
}
