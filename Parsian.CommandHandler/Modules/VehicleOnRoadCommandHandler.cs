using MediatR;
using Parsian.Command;
using Parsian.DomainModel.Modules.VehicleModel.Aggregates;
using Parsian.DomainModel.Modules.VehicleOnRoad.Aggregates;
using Parsian.Repository;

namespace Parsian.CommandHandler.Modules;

public class VehicleOnRoadCommandHandler : IRequestHandler<RecordPositionCommand>
{
    public readonly IContext Context;
    private readonly IRepository<Vehicle> _vehicleRepository;
    private readonly IRepository<VehicleOnRoad> _vehicleOnRoadRepository;

    public VehicleOnRoadCommandHandler(IContext context, IRepository<Vehicle> vehicleRepository, IRepository<VehicleOnRoad> vehicleOnRoadRepository)
    {
        Context = context;
        _vehicleRepository = vehicleRepository;
        _vehicleOnRoadRepository = vehicleOnRoadRepository;
    }

    public async Task<Unit> Handle(RecordPositionCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.SingleOrDefaultAsync(r => r.Plaque == request.Plaque);
        var vehicleOnRoadBuilder = vehicle.CreateVehicleOnRoadBuilder(vehicle);
        var vehicleOnRoad = vehicleOnRoadBuilder.SetDateTime(DateTime.Now).AddPoint(request.Longitude, request.Latitude).Build();
        _vehicleOnRoadRepository.Add(vehicleOnRoad);
        await Context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}