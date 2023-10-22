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
                    new("13184010", "265", complement: "UNASP-HT"),
                    new("13165000", "S/N", complement: "UNASP-EC", observation: "Condomínio das Pérolas")
                };

                _context.AddRange(addresses);
                await _context.SaveChangesAsync();
            }

            var buildings = _context.Buildings.ToList();

            if (!buildings.Any())
            {
                buildings = new()
                {
                    new(addresses[0], "Predio Escolar"),
                    new(addresses[0], "Biblioteca"),
                    new (addresses[1], "Predio da Faculdade"),
                    new (addresses[1], "Restaurante")
                };

                _context.AddRange(buildings);
                await _context.SaveChangesAsync();
            }

            var locations = _context.Locations.ToList();
            if (!locations.Any())
            {
                locations = new()
                {
                    new("Sala 1", "Térreo", buildings[0]),
                    new("Sala 2", "Térreo", buildings[0]),
                    new("Sala de informatica", "Térreo", buildings[1]),
                    new("Biblioteca", "Térreo", buildings[1]),
                    new("Sala 1", "Térreo", buildings[2]),
                    new("Sala 2", "Térreo", buildings[2]),
                    new("Restaurante", "Térreo", buildings[3]),
                    new("Cozinha", "Térreo", buildings[3])
                };

                _context.AddRange(locations);
                await _context.SaveChangesAsync();
            }

            var sensors = _context.Sensors.ToList();
            if (!sensors.Any())
            {
                sensors = new()
                {
                    new(1, "Porta", locations[0]), //SALA
                    new(2, "Porta", locations[1]), //SALA
                    new(3, "Porta", locations[2]), // LAB INFO
                    new(4, "Porta principal", locations[3]), // BIBLIOTECA
                    new(5, "Porta lateral", locations[3]), // BIBLIOTECA
                    new(6, "Porta", locations[4]), // SALA
                    new(7, "Porta", locations[5]), // SALA
                    new(8, "Porta principal", locations[6]), // RESTAURANTE
                    new(9, "Porta secundaria", locations[6]), // RESTAURANTE
                    new(10, "Porta lateral", locations[7]),  // COZINHA
                    new(11, "Porta interna", locations[7])  // COZINHA
                };
                
                _context.AddRange(sensors);
                await _context.SaveChangesAsync();
            }

            var equipments = _context.Equipments.ToList();
            if (!equipments.Any())
            {
                equipments = new()
                {
                    new("123", "Aspire F5 001"),
                    new("133", "Aspire F5 001"),
                    new("143", "Projetor Portatil 001"),
                    new("143", "Raspberry 4 001")
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
