using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Parsian.DomainModel.Modules.VehicleModel.Aggregates;
using Parsian.DomainModel.Modules.VehicleOnRoad.Aggregates;

namespace Parsian.Repository;

public class VehicleContext : DbContext, IContext
{
    public virtual DbSet<Vehicle> Vehicles { get; set; }
    public virtual DbSet<VehicleOnRoad> VehicleOnRoads { get; set; }
    public VehicleContext(DbContextOptions<VehicleContext> dbContextOptions)
        : base(dbContextOptions)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Scans a given assembly for all types that implement 
        //IEntityTypeConfiguration, and registers each one automatically
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

}