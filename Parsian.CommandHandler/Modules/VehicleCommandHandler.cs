using MediatR;
using Parsian.Command;
using Parsian.DomainModel.Modules.VehicleModel.Aggregates;
using Parsian.DomainModel.Seedworks;
using Parsian.Repository;

namespace Parsian.CommandHandler.Modules;

public class VehicleCommandHandler : IRequestHandler<RegisterVehicleCommand>
{
    public readonly IContext Context;
    private readonly IRepository<Vehicle> _vehicleRepository;

    public VehicleCommandHandler(IContext context, IRepository<Vehicle> vehicleRepository)
    {
        Context = context;
        _vehicleRepository = vehicleRepository;
    }

    public async Task<Unit> Handle(RegisterVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = new Vehicle(Guid.NewGuid(), request.Plaque);
        _vehicleRepository.Add(vehicle);
        if (await Context.SaveChangesAsync(cancellationToken) != 1)
        {
            throw new DomainException("");
        }
        return Unit.Value;
    }
}