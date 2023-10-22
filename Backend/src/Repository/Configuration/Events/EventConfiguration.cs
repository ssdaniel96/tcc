using Domain.Entities.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Events;

internal sealed class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.Sensor)
            .WithMany(p => p.Events)
            .HasForeignKey(p => p.SensorId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(p => p.Location)
            .WithMany(p => p.Events)
            .HasForeignKey(p => p.LocationId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(p => p.Equipment)
            .WithMany(p => p.Events)
            .HasForeignKey(p => p.EquipmentId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.Property(p => p.MovimentType)
            .IsRequired();

        builder.Property(p => p.EventDateTime)
            .IsRequired();

        builder.ToTable(nameof(Event));
    }
}
