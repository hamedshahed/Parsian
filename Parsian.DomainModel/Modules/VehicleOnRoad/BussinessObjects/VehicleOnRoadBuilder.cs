namespace Parsian.DomainModel.Modules.VehicleOnRoad.BussinessObjects;

public class VehicleOnRoadBuilder : IVehicleOnRoadBuilder
{
    public VehicleOnRoadBuilder(Aggregates.VehicleOnRoad vehicleOnRoad)
    {
        this._vehicleOnRoad = vehicleOnRoad;
    }

    private readonly Aggregates.VehicleOnRoad _vehicleOnRoad;

    public IVehicleOnRoadBuilder AddPoint(double longitude, double latitude)
    {
        _vehicleOnRoad.AddPoint(longitude, latitude);
        return this;
    }

    public IVehicleOnRoadBuilder AddSpeed(int speed)
    {
        _vehicleOnRoad.AddSpeed(speed);
        return this;
    }

    public IVehicleOnRoadBuilder AddFuel(int fuel)
    {
        _vehicleOnRoad.AddFuel(fuel);
        return this;
    }

    public IVehicleOnRoadBuilder SetDateTime(DateTime dateTime)
    {
        _vehicleOnRoad.AddDateTime(dateTime);
        return this;
    }

    public Aggregates.VehicleOnRoad Build()
    {
        return _vehicleOnRoad;
    }
}
