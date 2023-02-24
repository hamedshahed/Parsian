using NetTopologySuite.Geometries;
using Parsian.DomainModel.Modules.VehicleOnRoad.Aggregates;
using Parsian.Repository;

namespace Parsian.QueryService.Modules
{
    public class VehicleQueryService : IVehicleQueryService
    {
        private readonly IRepository<VehicleOnRoad> _vehicleOnRoadRepository;

        public VehicleQueryService(IRepository<VehicleOnRoad> vehicleOnRoadRepository)
        {
            _vehicleOnRoadRepository = vehicleOnRoadRepository;
        }

        public async Task<Point> GetCurrentPosition(Guid vehicleId)
        {
            var vehicleOnRoad = await _vehicleOnRoadRepository.SingleOrDefaultAsync(r => r.VehicleId.VehicleId == vehicleId);
            return vehicleOnRoad.Point;
        }

        public async Task<IEnumerable<Point>> GetPositions(Guid vehicleId, DateTime start, DateTime end)
        {
            var vehicleOnRoads = await _vehicleOnRoadRepository.GetAllAsync(r => r.VehicleId.VehicleId == vehicleId
                                                                           && r.DateTime > start && r.DateTime < end);
            return vehicleOnRoads.Select(r => r.Point);
        }
    }
}
