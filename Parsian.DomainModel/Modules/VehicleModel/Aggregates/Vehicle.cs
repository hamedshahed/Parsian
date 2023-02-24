using Parsian.DomainModel.Modules.VehicleModel.ValueObjects;
using Parsian.DomainModel.Modules.VehicleOnRoad.BussinessObjects;
using Parsian.DomainModel.Seedworks;

namespace Parsian.DomainModel.Modules.VehicleModel.Aggregates;

public class Vehicle : Entity<VehicleIdentifier>, IAggregateRoot
{
    protected Vehicle() { }
    public Vehicle(Guid id, string plaque) : base(new VehicleIdentifier(id))
    {
        Plaque = plaque;
        CreationDateTime = DateTime.Now;
    }

    public string Plaque { get; private set; }
    public DateTime CreationDateTime { get; private set; }

    public IVehicleOnRoadBuilder CreateVehicleOnRoadBuilder(Vehicle vehicle)
    {
        return VehicleOnRoad.Aggregates.VehicleOnRoad.GetBuilder(vehicle.Id);
    }
}