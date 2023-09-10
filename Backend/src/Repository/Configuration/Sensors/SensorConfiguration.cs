using Domain.Entities.Sensors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Sensors;

internal sealed class SensorConfiguration : IEntityTypeConfiguration<Sensor>
{
    public void Configure(EntityTypeBuilder<Sensor> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Description)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .IsRequired();

        builder.HasOne(p => p.Location)
            .WithMany()
            .HasForeignKey("LocationId")
            .IsRequired();

        builder.ToTable(nameof(Sensor), schema: "sensors");    
    }
}