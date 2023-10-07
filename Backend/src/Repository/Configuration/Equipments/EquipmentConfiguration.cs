using Domain.Entities.Equipments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Equipments;

internal sealed class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
{
    public void Configure(EntityTypeBuilder<Equipment> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Description)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.RfTag)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.ToTable(nameof(Equipment), schema: "equipments");
    }
}

