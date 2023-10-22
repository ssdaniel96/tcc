using Domain.Entities.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Locations;

internal sealed class BuildingConfiguration : IEntityTypeConfiguration<Building>
{
    public void Configure(EntityTypeBuilder<Building> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Description)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(p => p.Address)
            .WithMany(p => p.Buildings)
            .HasForeignKey(p => p.AddressId)
            .IsRequired();

        builder.ToTable(nameof(Building));
    }
}
