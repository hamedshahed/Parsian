using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTopologySuite.Geometries;

namespace Parsian.QueryService.Modules
{
    public interface IVehicleQueryService
    {
        Task<Point> GetCurrentPosition(Guid vehicleId);
        Task<IEnumerable<Point>> GetPositions(Guid vehicleId, DateTime start, DateTime end);
    }
}
