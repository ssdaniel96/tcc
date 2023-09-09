using Api.Infrastructure.Extensions;
using Api.Infrastructure.Filters;
using IoC;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration)
                .AddEndpointsApiExplorer()
                .AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddMvcCore(config =>
{
    config.Filters.Add<ExceptionFilter>();
    config.Filters.Add<TransactionFilter>();
});

var app = builder.Build();

app.UseCors(config =>
{
    config.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.Services.ExecuteSeeders().Wait();
}
else
{
    app.UseHttpsRedirection();
}

app.MapControllers();

app.Run();