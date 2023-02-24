using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parsian.DomainModel.Modules.VehicleModel.ValueObjects;

namespace Parsian.Repository.Configurations;

public class VehicleIdentifierMap : IEntityTypeConfiguration<VehicleIdentifier>
{
    public void Configure(EntityTypeBuilder<VehicleIdentifier> builder)
    {
        builder.Property<Guid>("Id").IsRequired();
        builder.HasKey("Id");
    }
}