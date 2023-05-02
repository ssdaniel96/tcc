using Domain.Entities.Equipments;
using Domain.Entities.Events;
using Domain.Entities.Locations;
using Domain.Entities.People;
using Repository.Context;

namespace Repository.Seeders
{
    public sealed class Seeder
    {
        private ApplicationDbContext _context;

        public Seeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            if (!_context.Addresses.Any())
            {
                List<Address> addresses = new()
                {
                    new("13182823", "43", complement: "Bl B Apt 30"),
                    new("13192823", "700", complement: "Bl A Apt 55", observation: "Condomínio das Pérolas"),
                    new("13182800", "71A")
                };

                _context.AddRange(addresses);
                await _context.SaveChangesAsync();

                List<Building> buildings = new()
                {
                    new(addresses[0], "Prédio de TI"),
                    new(addresses[0], "Prédio de RH"),
                    new(addresses[1], "Prédio de Commerce"),
                    new(addresses[2], "Prédio Social")
                };

                _context.AddRange(buildings);
                await _context.SaveChangesAsync();

                List<Location> locations = new()
                {
                    new("Sala 1", "1", buildings[0]),
                    new("Sala 2", "1", buildings[0]),
                    new("Sala 1", "2", buildings[1]),
                    new("Sala 3", "Térreo", buildings[2]),
                    new("Auditório", "Térreo", buildings[3])
                };

                _context.AddRange(locations);
                await _context.SaveChangesAsync();

                List<Collaborator> collaborators = new()
                {
                    new("Daniel Soares"),
                    new("Antônio Jefferson"),
                    new("Richard Baldin")
                };

                _context.AddRange(collaborators);
                await _context.SaveChangesAsync();

                List<Equipment> equipments = new()
                {
                    new("123", "IPhone", collaborators[0]),
                    new("123", "Notebook", collaborators[1]),
                    new("123", "Prancha de Surf", collaborators[2]),
                };

                _context.AddRange(equipments);
                await _context.SaveChangesAsync();

                List<MovimentType> movimentTypes = new()
                {
                    new("IN"),
                    new("OUT")
                };

                _context.AddRange(movimentTypes);
                await _context.SaveChangesAsync();
            }
        }
    }
}
