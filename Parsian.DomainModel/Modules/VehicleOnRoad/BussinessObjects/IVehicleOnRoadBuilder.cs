using NetTopologySuite.Geometries;
using Parsian.DomainModel.Modules.VehicleModel.Aggregates;

namespace Parsian.DomainModel.Modules.VehicleOnRoad.BussinessObjects;

public interface IVehicleOnRoadBuilder
{
    IVehicleOnRoadBuilder AddPoint(double longitude, double latitude);
    IVehicleOnRoadBuilder AddSpeed(int speed);
    IVehicleOnRoadBuilder AddFuel(int fuel);
    IVehicleOnRoadBuilder SetDateTime(DateTime dateTime);
    Aggregates.VehicleOnRoad Build();
}