using IoC;
using Repository.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    ExecuteSeeders(app.Services);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void ExecuteSeeders(IServiceProvider services)
{
    using var scope = services.CreateScope();
    var service = scope.ServiceProvider.GetService<ISeeder>()
        ?? throw new ArgumentException("Service cant be null");
    service.SeedAsync().Wait();



}
