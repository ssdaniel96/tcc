using Domain.Entities.Events;
using Repository.Context;

namespace Repository.Seeders
{
    public sealed class Seeder : ISeeder
    {
        private ApplicationDbContext _context;

        public Seeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            var addresses = _context.Addresses.ToList();
            if (!addresses.Any())
            {
                addresses = new()
                {
                    new("13182823", "43", complement: "Bl B Apt 30"),
                    new("13192823", "700", complement: "Bl A Apt 55", observation: "Condomínio das Pérolas"),
                    new("13182800", "71A")
                };

                _context.AddRange(addresses);
                await _context.SaveChangesAsync();
            }

            var buildings = _context.Buildings.ToList();

            if (!buildings.Any())
            {
                buildings = new()
                {
                    new(addresses[0], "Prédio de TI"),
                    new(addresses[0], "Prédio de RH"),
                    new(addresses[1], "Prédio de Commerce"),
                    new(addresses[2], "Prédio Social")
                };

                _context.AddRange(buildings);
                await _context.SaveChangesAsync();
            }

            var locations = _context.Locations.ToList();
            if (!locations.Any())
            {
                locations = new()
                {
                    new("Sala 1", "1", buildings[0]),
                    new("Sala 2", "1", buildings[0]),
                    new("Sala 1", "2", buildings[1]),
                    new("Sala 3", "Térreo", buildings[2]),
                    new("Auditório", "Térreo", buildings[3])
                };

                _context.AddRange(locations);
                await _context.SaveChangesAsync();
            }

            var equipments = _context.Equipments.ToList();
            if (!equipments.Any())
            {
                equipments = new()
                {
                    new("123", "IPhone"),
                    new("133", "Notebook"),
                    new("143", "Prancha de Surf"),
                };

                _context.AddRange(equipments);
                await _context.SaveChangesAsync();
            }

            if (!_context.MovimentTypes.Any())
            {
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
