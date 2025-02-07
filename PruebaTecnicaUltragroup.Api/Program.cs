using Ecommerce.Services.WebApi.Modules.Injection;
using Ecommerce.Services.WebApi.Modules.Mapper;
using Ecommerce.Services.WebApi.Modules.Validator;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaUltragroup.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Add connection string to database
builder.Services.AddDbContext<DbpruebaUltragroupContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PruebaUltragroup")));
// Automapper configuration
builder.Services.AddMapper();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Dependency injection configuration
builder.Services.AddInjection();
// Fluent validation configuration
builder.Services.AddValidator();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
