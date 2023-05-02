using Domain.Entities.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.People;

internal sealed class CollaboratorConfiguration : IEntityTypeConfiguration<Collaborator>
{
    public void Configure(EntityTypeBuilder<Collaborator> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.ToTable(nameof(Collaborator), schema: "people");
    }
}
