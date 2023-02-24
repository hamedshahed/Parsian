using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Parsian.CommandHandler.Modules;
using Parsian.QueryService.Modules;
using Parsian.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(VehicleCommandHandler));
builder.Services.AddDbContext<VehicleContext>(r => r.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    x => x.UseNetTopologySuite()));
builder.Services.AddScoped<IContext, VehicleContext>();
builder.Services.AddScoped<DbContext, VehicleContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IVehicleQueryService, VehicleQueryService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
