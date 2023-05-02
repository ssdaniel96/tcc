using Domain.Entities.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Events;

internal sealed class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.Location)
            .WithMany()
            .HasForeignKey("LocationId")
            .IsRequired();

        builder.HasOne(p => p.Equipment)
            .WithMany(p => p.Events)
            .HasForeignKey("EquipmentId")
            .IsRequired();

        builder.Property(p => p.MovimentType)
            .IsRequired(); // converson int to MovimentType

        builder.Property(p => p.EventDateTime)
            .IsRequired();

        builder.ToTable(nameof(Event), schema: "events");
    }
}
