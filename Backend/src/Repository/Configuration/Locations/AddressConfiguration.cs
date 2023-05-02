using Domain.Entities.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Locations;

internal sealed class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.ZipCode)
            .HasColumnType("varchar")
            .HasMaxLength(8)
            .IsRequired();

        builder.Property(p => p.Number)
            .HasColumnType("varchar")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(p => p.Complement)
            .HasColumnType("varchar")
            .HasMaxLength(8);

        builder.Property(p => p.Observation)
            .HasColumnType("varchar")
            .HasMaxLength(8);

        builder.ToTable(nameof(Address), schema: "locations");
    }
}
