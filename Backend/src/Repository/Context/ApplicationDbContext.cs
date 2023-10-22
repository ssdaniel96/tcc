using Domain.Entities.Equipments;
using Domain.Entities.Events;
using Domain.Entities.Locations;
using Domain.Entities.Sensors;
using Microsoft.EntityFrameworkCore;

namespace Repository.Context;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<Equipment> Equipments { get; private set; }
    public DbSet<Event> Events { get; private set; }
    public DbSet<Address> Addresses { get; private set; }
    public DbSet<Building> Buildings { get; private set; }
    public DbSet<Location> Locations { get; private set; }
    public DbSet<MovimentType> MovimentTypes { get; private set; }
    
    public DbSet<Sensor> Sensors { get; private set; }

#pragma warning disable CS8618
    public ApplicationDbContext(DbContextOptions options) : base(options)
#pragma warning restore CS8618
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
