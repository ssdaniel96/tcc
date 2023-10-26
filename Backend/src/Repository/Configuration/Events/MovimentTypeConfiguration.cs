using Domain.Entities.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Events
{
    internal sealed class MovimentTypeConfiguration : IEntityTypeConfiguration<MovimentType>
    {
        public void Configure(EntityTypeBuilder<MovimentType> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Description)
                .HasColumnType("varchar")
                .HasMaxLength(3)
                .IsRequired();

            builder.ToTable(nameof(MovimentType), schema: "events");
        }
    }
}
