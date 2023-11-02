using System.Globalization;
using Application.Shared.Dtos;
using Application.UseCases.Events.Commands.Capture;
using Application.UseCases.Events.Dtos;
using Application.UseCases.Events.Queries.Get;
using Domain.Repositories.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repository.Context;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HealthCheckController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public HealthCheckController(ApplicationDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }

    [HttpGet]
    public async Task<ActionResult> GetStatus()
    {
        var author = "Daniel Soares";
        var databaseOnline = await _dbContext.Database.CanConnectAsync();
        var datetime = DateTime.Now.ToString(CultureInfo.CurrentCulture);
        var culture = CultureInfo.CurrentCulture.Name;
        var version = _configuration["Version"];
        if (string.IsNullOrEmpty(version))
            version = "Unavailable";

        return Ok(new
        {
            author = $"Made by: {author}",
            serverTime = datetime,
            culture,
            apiVersion = version,
            status = databaseOnline ? "Healthy" : "Unhealthy",
            services = new {
                database = databaseOnline ? "Healthy" : "Unhealthy" 
            }
        });


    }
}
