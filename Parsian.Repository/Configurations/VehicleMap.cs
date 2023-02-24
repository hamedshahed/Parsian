using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parsian.DomainModel.Modules.VehicleModel.Aggregates;
using Parsian.DomainModel.Modules.VehicleModel.ValueObjects;

namespace Parsian.Repository.Configurations;

public class VehicleMap:IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasConversion<Guid>(id =>
                id.VehicleId, dbId => new VehicleIdentifier(dbId));
    }
}