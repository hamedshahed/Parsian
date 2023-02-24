using NetTopologySuite.Geometries;
using Parsian.DomainModel.Modules.VehicleModel.ValueObjects;
using Parsian.DomainModel.Modules.VehicleOnRoad.BussinessObjects;
using Parsian.DomainModel.Seedworks;

namespace Parsian.DomainModel.Modules.VehicleOnRoad.Aggregates;

public class VehicleOnRoad : Entity, IAggregateRoot
{
    protected VehicleOnRoad()
    {
    }

    private VehicleOnRoad(VehicleIdentifier vehicleId)
    {
        this.VehicleId = vehicleId;
    }
    public static IVehicleOnRoadBuilder GetBuilder(VehicleIdentifier vehicleId)
        => new VehicleOnRoadBuilder(new VehicleOnRoad(vehicleId));

    public VehicleIdentifier VehicleId { get; private set; }
    public Point Point { get; private set; }
    public DateTime DateTime { get; private set; }
    public int Fuel { get; private set; }
    public int Speed { get; private set; }

    public void AddPoint(double longitude, double latitude)
    {
        this.Point = new Point(longitude, latitude);
    }

    public void AddDateTime(DateTime dateTime)
    {
        this.DateTime = dateTime;
    }

    public void AddFuel(int fuel)
    {
        this.Fuel = fuel;
    }

    public void AddSpeed(int speed)
    {
        this.Speed = speed;
    }
}